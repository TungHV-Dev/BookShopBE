using BookShopBE.Common.Dtos;
using System;

namespace BookShopBE.Data.Models
{
    public class Order : ModelBase
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int OrderNumber { get; set; }
        public double TotalMoney { get; set; }
        public bool IsSuccess { get; set; }
    }
}
