using BookShopBE.Common.Dtos;

namespace BookShopBE.Data.Dtos.Books
{
    public class FilterBookRequest : BaseQuery
    {
        public string Genre { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
