using BookShopBE.Common.Dtos;
using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;
using BookShopBE.Data.Requests;
using BookShopBE.Data.Responses;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task Add(StoreRequest<CreatedDto> request);
        Task Update(int storeId, StoreRequest<ModifiedDto> request);
        Task<StoreResponse<BookDto>> GetBooksOfStore(int storeId);
    }
}
