using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly BookShopDbContext dbContext;
        public CustomerRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<Customer> GetById(Guid customerId)
        {
            return await dbContext.Customers.Where(cus => cus.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
