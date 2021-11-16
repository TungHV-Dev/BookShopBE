using BookShopBE.Common.Repository;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<CustomerHasOrder>
    {
        Task<CustomerHasOrder> GetById(string customerId);
        Task Add(CustomerHasOrder customer);
    }
}
