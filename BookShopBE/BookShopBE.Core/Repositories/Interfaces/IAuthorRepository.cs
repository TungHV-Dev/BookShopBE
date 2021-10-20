using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos.Authors;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task Add(AddAuthorRequest request);
        Task Update(UpdateAuthorRequest request);
        Task<AuthorResponse<BookDto>> GetBooksOfAuthor(int authorId);
    }
}
