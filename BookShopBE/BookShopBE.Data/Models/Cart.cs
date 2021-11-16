using BookShopBE.Common.Dtos;

namespace BookShopBE.Data.Models
{
    public class Cart : ModelBase
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public bool IsOrder { get; set; }
    }
}
