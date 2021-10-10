using BookShopBE.Data.BaseModel;
using System.Collections.Generic;

namespace BookShopBE.Data.Models
{
    public class Book : ModelBase
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookStores = new HashSet<BookStore>();
        }

        public int? Rate { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookStore> BookStores { get; set; }
    }
}
