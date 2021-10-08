using BookShopBE.Common.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Store : ModelBase
    {
        public Store()
        {
            BookStores = new HashSet<BookStore>();
        }

        [Required]
        [MaxLength(100)]
        public string StoreName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<BookStore> BookStores { get; set; }
    }
}
