using BookShopBE.Data.BaseModel;
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

        public string Country { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
