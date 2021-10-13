using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Responses
{
    public class StoreResponse<TDto> where TDto : BookDto
    {
        public StoreDto storeDto { get; set; }
        public List<TDto> Dtos { get; set; }
    }
}
