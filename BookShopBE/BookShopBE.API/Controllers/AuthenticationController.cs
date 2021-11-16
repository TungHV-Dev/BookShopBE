using BookShopBE.Common.Constants;
using BookShopBE.Common.Responses;
using BookShopBE.Core.Services.Interfaces;
using BookShopBE.Data.Dtos.Authentications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookShopBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        #region Properties
        private readonly IAuthenticationServices _authenticationServices;
        #endregion

        #region Contructor
        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }
        #endregion

        #region Public
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterRequest request)
        {
            var result = await _authenticationServices.RegisterAsync(request);

            if(!result.IsSuccess)
            {
                switch(result.Error.Code)
                {
                    case 400:
                        return BadRequest(result);
                    case 404:
                        return NotFound(result);
                }
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] AuthenticationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(Result<AuthenticationResponse>.Fail(new Error
                {
                    Code = 400,
                    Message = ErrorDetails.MODEL_IS_INVALID
                }));
            }

            var result = await _authenticationServices.AuthenticateAsync(request);
            if(!result.IsSuccess)
            {
                switch(result.Error.Code)
                {
                    case 400:
                        return BadRequest(result);
                    case 404:
                        return NotFound(result);
                }
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", result.Data.RefreshToken, cookieOptions);
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Role")]
        [Authorize(Roles = RoleDetails.ADMINISTRATOR)]
        public async Task<IActionResult> AddRole([FromForm] AddRoleModel model)
        {
            var response = await _authenticationServices.AddRoleToUserAsync(model);
            return Ok(response);
        }

        [HttpPost]
        [Route("Refresh-Token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _authenticationServices.RefreshToken(refreshToken);

            if(!response.IsSuccess)
            {
                if(response.Error.Code == 404)
                {
                    return NotFound(response);
                }
                return BadRequest(response);
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", response.Data.RefreshToken, cookieOptions);

            return Ok(response);
        }

        [HttpGet]
        [Route("Get-Refresh-Token")]
        public async Task<IActionResult> GetRefreshTokens(string userId)
        {
            var user = await _authenticationServices.GetUserById(userId);
            return Ok(user.Data.RefreshTokens);
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new Result
                {
                    IsSuccess = false,
                    Error = new Error { Code = 400, Message = ErrorDetails.TOKEN_IS_NULL }
                });
            }

            var response = await _authenticationServices.RevokeToken(token);
            if(!response.IsSuccess)
            {
                if(response.Error.Code == 400)
                {
                    return BadRequest(response);
                }
                return NotFound(response);
            }
            return Ok(response);
        }

        #endregion
    }
}
