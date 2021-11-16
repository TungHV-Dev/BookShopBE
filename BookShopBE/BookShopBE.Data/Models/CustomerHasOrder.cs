using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopBE.Data.Models
{
    public class CustomerHasOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
