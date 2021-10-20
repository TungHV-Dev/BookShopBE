using System;

namespace BookShopBE.Data.Dtos.Orders
{
    public class OrderDto
    {
        public Guid CustomerId { get; set; }
        public int BookId { get; set; }
        public int OrderNumber { get; set; }
    }
}
