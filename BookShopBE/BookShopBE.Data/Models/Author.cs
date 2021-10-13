using BookShopBE.Common.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Author : ModelBase
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
