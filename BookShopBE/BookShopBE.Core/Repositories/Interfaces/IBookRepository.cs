using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos.Authors;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task Add(AddBookRequest request);
        Task Update(UpdateBookRequest request);
        Task<BookResponse<AuthorDto>> GetAuthorsOfBook(int bookId);
    }
}
