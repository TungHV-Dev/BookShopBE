using BookShopBE.Common.Dtos;
using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;
using BookShopBE.Data.Requests;
using BookShopBE.Data.Responses;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task Add(AuthorRequest<CreatedDto> request);
        Task Update(int authorId, AuthorRequest<ModifiedDto> request);
        Task<AuthorResponse<BookDto>> GetBooksOfAuthor(int authorId);
    }
}
