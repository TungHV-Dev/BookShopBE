using BookShopBE.Common.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopBE.Data.Models
{
    public class Feedback : ModelBase
    {
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerHasOrder Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int StarRate { get; set; }
        public string Message { get; set; }
    }
}
