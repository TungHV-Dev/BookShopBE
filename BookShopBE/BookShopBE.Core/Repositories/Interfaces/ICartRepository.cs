using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos.Carts;
using BookShopBE.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task Add(CartDto cartDto);
        Task<int> GetCartId(CartDto cartDto);
        Task<List<Cart>> GetAllCartOfUser(string userId);
        Task DeleteRange(IEnumerable<Cart> cart);
    }
}
