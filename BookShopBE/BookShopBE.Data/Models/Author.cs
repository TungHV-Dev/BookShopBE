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
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
