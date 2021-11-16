using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class CustomerRepository : RepositoryBase<CustomerHasOrder>, ICustomerRepository
    {
        private readonly BookShopDbContext dbContext;
        public CustomerRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<CustomerHasOrder> GetById(string customerId)
        {
            return await dbContext.CustomerHasOrders.Where(cus => cus.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public async Task Add(CustomerHasOrder customer)
        {
            dbContext.CustomerHasOrders.Add(customer);
            await dbContext.SaveChangesAsync();
        }


    }
}
