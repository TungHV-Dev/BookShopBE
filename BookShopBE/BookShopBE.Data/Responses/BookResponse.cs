using BookShopBE.Common.Dtos;
using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Responses
{
    public class BookResponse : BookDto
    {

    }
    public class BookResponse<TDto> where TDto : DtoBase
    {
        public BookDto bookDto { get; set; }
        public List<TDto> Dtos { get; set; }
    }
}
