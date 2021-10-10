using BookShopBE.Common.Paging;
using BookShopBE.Data.BaseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : ModelBase
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<PagingResponse<TEntity>> GetAllPaging(PagingRequest request);
        Task<int> Delete(int id);
    }
}
