using BookShopBE.Common.Repository;
using BookShopBE.Data.Models;
using System;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetById(Guid customerId);
    }
}
