using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public double TotalMoney { get; set; }
        public bool OrderStatus { get; set; }
    }
}
