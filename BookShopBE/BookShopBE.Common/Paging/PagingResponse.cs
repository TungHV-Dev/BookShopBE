using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopBE.Common.Paging
{
    public class PagingResponse<T>
    {
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalItem { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
