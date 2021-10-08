using BookShopBE.Common.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Book : ModelBase
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookStores = new HashSet<BookStore>();
        }

        [Required]
        public string Title { get; set; }

        public int? Rate { get; set; }

        public string Genre { get; set; }

        [Required]
        public double Price { get; set; }

        public string Url { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookStore> BookStores { get; set; }
    }
}
