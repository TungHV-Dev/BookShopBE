using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Carts;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface ICartServices
    {
        Task<Result<CartResponse>> GetCartsOfUser(string userId);
        Task<Result> AddBookToCart(CartDto cartDto);
        Task<Result> DeleteBookFromCart(CartDto cartDto);
        Task<Result> DeleteCartsOfUser(string userId);
    }
}
