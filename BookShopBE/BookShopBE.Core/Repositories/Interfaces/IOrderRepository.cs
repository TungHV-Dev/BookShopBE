using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Models;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task Add(Order order);
        Task Update(EditOrderDto dto);
    }
}
