using BookShopBE.Core.Repositories.Interfaces;
using BookShopBE.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopBE.Core.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookShopDbContext _context;
        public OrderRepository(BookShopDbContext context)
        {
            _context = context;
        }



    }
}
