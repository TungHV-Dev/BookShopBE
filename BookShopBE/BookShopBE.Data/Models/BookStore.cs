using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopBE.Data.Models
{
    public class BookStore
    {
        public int Id { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
