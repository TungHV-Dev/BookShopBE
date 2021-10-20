using BookShopBE.Common.Dtos;
using BookShopBE.Common.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopBE.Common.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<int> Delete(int id);
    }
}
