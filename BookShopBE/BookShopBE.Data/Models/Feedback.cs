using BookShopBE.Common.Dtos;
using System;

namespace BookShopBE.Data.Models
{
    public class Feedback : ModelBase
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int StarRate { get; set; }
        public string Message { get; set; }
    }
}
