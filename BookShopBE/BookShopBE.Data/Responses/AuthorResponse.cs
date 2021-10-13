using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Responses
{
    public class AuthorResponse<TDto> where TDto : BookDto
    {
        public AuthorDto authorDto { get; set; }
        public List<TDto> Dtos { get; set; }
    }
}
