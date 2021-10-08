using BookShopBE.Common.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Publisher : ModelBase
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
