using BookShopBE.Common.Dtos;
using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Requests
{
    public class StoreRequest
    {
        public StoreDto storeDto { get; set; }
        public bool IsAddOrUpdateBooks { get; set; }
        public HashSet<int> bookIds { get; set; }
    }

    public class StoreRequest<TDto> where TDto : CreateOrModifyDto
    {
        public StoreDto<TDto> storeDto { get; set; }
        public bool IsAddOrUpdateBooks { get; set; }
        public HashSet<int> bookIds { get; set; }
    }
}
