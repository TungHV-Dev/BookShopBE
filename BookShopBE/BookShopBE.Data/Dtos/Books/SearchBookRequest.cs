using BookShopBE.Common.Dtos;

namespace BookShopBE.Data.Dtos.Books
{
    public class SearchBookRequest : BaseQuery
    {
        public string SearchingContent { get; set; }
    }
}
