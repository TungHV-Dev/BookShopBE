using BookShopBE.Common.Repository;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUserName(string userName);
        Task UpdateUser(User user);
        Task<User> GetById(string userId);
        Task<bool> Delete(string userId);
    }
}
