using AutoMapper;
using BookShopBE.Common.Constants;
using BookShopBE.Common.Enums;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Authentications;
using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationServices(
            IMapper mapper,
            UserManager<User> userManager,
            IOptions<JWTSettings> jwtSettings, 
            SignInManager<User> signInManager, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        #region Public
        public async Task<Result<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return Result<AuthenticationResponse>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.USERNAME_DOES_NOT_EXIST
                });
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Result<AuthenticationResponse>.Fail(new Error
                {
                    Code = 400,
                    Message = ErrorDetails.USERNAME_OR_PASSWORD_IS_INVALID
                });
            }

            //generate jwt token
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            response.IsVerified = true;

            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;

            // generate refreshtoken
            var refreshToken = GenerateRefreshToken();

            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.ExpiryDate;
            // save refresh token
            user.RefreshTokens.Add(refreshToken);
            await _unitOfWork.Users.UpdateUser(user);
            await _unitOfWork.CompleteAsync(); 
            return Result<AuthenticationResponse>.Success(response);
        }

        public async Task<Result<AuthenticationResponse>> RefreshToken(string token)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                return Result<AuthenticationResponse>.Fail(new Error
                {
                    Code = 404,
                    Message = ErrorDetails.NO_USER_WITH_TOKEN
                });
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                return Result<AuthenticationResponse>.Fail(new Error
                {
                    Code = 400,
                    Message = ErrorDetails.TOKEN_IS_NOLONGER_ACTIVE
                });
            }

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken();
            refreshToken.RevokedDate = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            await _unitOfWork.Users.UpdateUser(user);
            await _unitOfWork.CompleteAsync();

            // generate new jwt
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.ExpiryDate;

            return Result<AuthenticationResponse>.Success(response);
        }

        public async Task<Result> RevokeToken(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            // return false if no user found with token
            if (user == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.NO_USER_WITH_TOKEN }
                };
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.TOKEN_IS_NOLONGER_ACTIVE }
                };
            }

            // revoke token and save
            refreshToken.RevokedDate = DateTime.UtcNow;

            await _unitOfWork.Users.UpdateUser(user);
            await _unitOfWork.CompleteAsync();

            return new Result { IsSuccess = true, Error = null };
        }

        public async Task<Result> RegisterAsync(RegisterRequest request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.USERNAME_HAS_ALREADY_USED }
                };
            }
            
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.USER_EMAIL_HAS_ALREADY_EXISTED }
                };
            }

            var passwordValidator = new PasswordValidator<User>();
            var checkPasswordValidator = await passwordValidator.ValidateAsync(_userManager, null, request.Password);
            if (!checkPasswordValidator.Succeeded)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.PASSWORD_IS_INVALID }
                };
            }

            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Customer.ToString());
                await _unitOfWork.CompleteAsync();
                return new Result { IsSuccess = true, Error = null };
            }

            return new Result
            {
                IsSuccess = false,
                Error = new Error { Code = 400, Message = ErrorDetails.CREATE_USER_FAILED }
            };
        }

        public async Task<Result> AddRoleToUserAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.USERNAME_DOES_NOT_EXIST }
                };
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roleExists = Enum.GetNames(typeof(Roles)).Any(x => x.ToLower() == model.Role.ToLower());
                if (roleExists)
                {
                    var validRole = Enum.GetValues(typeof(Roles)).Cast<Roles>().Where(x => x.ToString().ToLower() == model.Role.ToLower()).FirstOrDefault();
                    await _userManager.AddToRoleAsync(user, validRole.ToString());
                    return new Result { IsSuccess = true, Error = null };
                }
                return new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 404, Message = ErrorDetails.ROLE_DOES_NOT_EXIST }
                };
            }
            return new Result
            {
                IsSuccess = false,
                Error = new Error { Code = 400, Message = ErrorDetails.INCORRECT_CREDENTIALS }
            };
        }

        public async Task<Result<User>> GetUserById(string userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            return Result<User>.Success(user);
        }

        #endregion Public

        #region Private
        private async Task<JwtSecurityToken> GenerateJWToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedDate = DateTime.UtcNow
            };
        }

        #endregion Private
    }
}
