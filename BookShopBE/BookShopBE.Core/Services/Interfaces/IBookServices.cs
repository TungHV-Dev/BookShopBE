using BookShopBE.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IBookServices
    {
        Task<BookResponse> GetBook(int bookId);
        Task<IEnumerable<BookResponse>> GetAllBook();
        Task<IEnumerable<BookResponse>> Search(string content);
        Task<IEnumerable<BookResponse>> Filter(string genre, int minPrice, int maxPrice);
    }
}
