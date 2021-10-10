using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StoreId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalMoney { get; set; }
    }
}
