using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task Update(EditOrderDto dto)
        {
            var order = dbContext.Orders.Where(x => x.Id == dto.OrderId && x.CustomerId == dto.CustomerId)
                .Include(x => x.Book)
                .FirstOrDefault();
            order.BookId = dto.BookId;
            order.OrderNumber = dto.OrderNumber;
            order.TotalMoney = dto.OrderNumber * order.Book.Price;
            order.DeliveryAddress = dto.DeliveryAddress;
            await dbContext.SaveChangesAsync();
        }

        #endregion Public
    }
}
