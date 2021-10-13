using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CustomerName { get; set; }

        [MaxLength(100)]
        public string CustomerAddress { get; set; }

        public string CustomerEmail { get; set; }

        [MaxLength(10)]
        public string CustomerMobile { get; set; }
    }
}
