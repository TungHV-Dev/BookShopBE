using System;

namespace BookShopBE.Data.Dtos.Carts
{
    public class CartDto
    {
        public Guid CustomerId { get; set; }
        public int BookId { get; set; }
    }
}
