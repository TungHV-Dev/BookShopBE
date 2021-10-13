using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface ICartServices
    {
        Task AddBookToCart(int customerId, int bookId);
        Task DeleteBookFromCart(int customerId, int bookId);
        Task DeleteAllBookFromCart(int customerId);
    }
}
