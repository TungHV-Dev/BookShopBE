using BookShopBE.Common.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Book : ModelBase
    {
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
            Carts = new List<Cart>();
            Orders = new List<Order>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public float Rate { get; set; }

        public string Genre { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Url { get; set; }

        public string PublisherName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
