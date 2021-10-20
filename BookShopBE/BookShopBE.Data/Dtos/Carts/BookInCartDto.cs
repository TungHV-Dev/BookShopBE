using System;

namespace BookShopBE.Data.Dtos.Carts
{
    public class BookInCartDto
    {
        public int CartId { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public double BookPrice { get; set; }
        public string BookUrl { get; set; }
        public string PublisherName { get; set; }
        public bool IsOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
