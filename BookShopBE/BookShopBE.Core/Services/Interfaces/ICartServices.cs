using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Carts;
using System;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface ICartServices
    {
        Task<Result<CartResponse>> GetCartsOfCustomer(Guid customerId);
        Task<Result> AddBookToCart(CartDto cartDto);
        Task<Result> DeleteBookFromCart(CartDto cartDto);
        Task<Result> DeleteCartOfCustomer(Guid customerId);
    }
}
