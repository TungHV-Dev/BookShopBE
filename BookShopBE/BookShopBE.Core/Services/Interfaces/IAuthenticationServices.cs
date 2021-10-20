using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Authentications;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IAuthenticationServices
    {
        Task<Result<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<Result> RegisterAsync(RegisterRequest request);
        Task<Result> AddRoleToUserAsync(AddRoleModel model);
        Task<Result<AuthenticationResponse>> RefreshToken(string token);
        Task<Result> RevokeToken(string token);
        Task<Result<User>> GetUserById(string id);
    }
}
