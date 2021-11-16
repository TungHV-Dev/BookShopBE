using BookShopBE.Common.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopBE.Data.Models
{
    public class Order : ModelBase
    {
        [Required]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerHasOrder Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int OrderNumber { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }
        public double TotalMoney { get; set; }
        public bool IsSuccess { get; set; }
    }
}
