using System;

namespace BookShopBE.Data.Models
{
    public class BookStore
    {
        public int Id { get; set; }

        public int? OrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public double? TotalMoney { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
