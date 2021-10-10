using BookShopBE.Common.Enums;

namespace BookShopBE.Common.Paging
{
    public class PagingRequest
    {
        public int? PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortType? Sort { get; set; }
        public string Search { get; set; }
    }
}
