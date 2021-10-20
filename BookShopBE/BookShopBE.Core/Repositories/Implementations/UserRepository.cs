using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(BookShopDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _userManager.Users.Where(s => s.UserName.ToLower() == userName.ToLower()).SingleOrDefaultAsync();
            return user;
        }

        public async Task UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task<User> GetById(string userId)
        {
            var user = await _userManager.Users.Where(s => s.Id == userId).SingleOrDefaultAsync();
            return user;
        }

        public async Task<bool> Delete(string userId)
        {
            var user = await _userManager.Users.Where(s => s.Id == userId).SingleOrDefaultAsync();
            if (user == null) return false;

            await _userManager.DeleteAsync(user);
            return true;
        }
    }
}
