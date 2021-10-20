using BookShopBE.Common.Dtos;
using System;

namespace BookShopBE.Data.Models
{
    public class Cart : ModelBase
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public bool IsOrder { get; set; }
    }
}
