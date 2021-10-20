using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository 
    {
        #region Properties
        private readonly BookShopDbContext dbContext;
        #endregion Properties

        #region Contructor
        public OrderRepository(BookShopDbContext context) : base(context)
        {
            dbContext = context;
        }
        #endregion Contructor

        #region Public
        public async Task Add(Order order)
        {
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();
        }

        public async new Task Delete(int orderId)
        {
            var order = await GetById(orderId);
            order.IsSuccess = false;
            await dbContext.SaveChangesAsync();
        }

        #endregion Public
    }
}
