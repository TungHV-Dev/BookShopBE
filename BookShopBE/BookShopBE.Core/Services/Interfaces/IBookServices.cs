using BookShopBE.Common.Dtos;
using BookShopBE.Common.Responses;
using BookShopBE.Data.Dtos.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IBookServices
    {
        Task<Result<BookResponse>> GetBook(int bookId);
        Task<Result<IEnumerable<BookResponse>>> GetAllBook(BaseQuery query);
        Task<Result<IEnumerable<BookResponse>>> Search(SearchBookRequest request);
        Task<Result<IEnumerable<BookResponse>>> Filter(FilterBookRequest request);
        Task<Result> AddBook(AddBookRequest request);
        Task<Result> UpdateBook(UpdateBookRequest request);
        Task<Result> DeleteBook(int bookId);
    }
}
