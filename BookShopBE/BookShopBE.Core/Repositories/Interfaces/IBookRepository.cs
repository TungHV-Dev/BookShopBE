using BookShopBE.Common.Dtos;
using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;
using BookShopBE.Data.Requests;
using BookShopBE.Data.Responses;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task Add(BookRequest<CreatedDto> request);
        Task Update(int bookId, BookRequest<ModifiedDto> request);
        Task<BookResponse<AuthorDto>> GetAuthorsOfBook(int bookId);
        Task<BookResponse<StoreDto>> GetStoresOfBook(int bookId);
    }
}
