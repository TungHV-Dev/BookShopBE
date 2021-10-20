using BookShopBE.Common.Dtos;
using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Users;
using BookShopBE.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<Result<IEnumerable<UserDto>>> GetAllUsers(BaseQuery query);
        Task<Result<UserDto>> GetUser(string userId);
        Task<Result> UpdateUser(UserDto userDto);
        Task<Result> DeleteUser(string userId);
    }
}
