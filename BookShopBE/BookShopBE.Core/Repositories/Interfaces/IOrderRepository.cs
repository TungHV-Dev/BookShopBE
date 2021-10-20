using BookShopBE.Common.Repository;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBE.Core.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task Add(Order order);
    }
}
