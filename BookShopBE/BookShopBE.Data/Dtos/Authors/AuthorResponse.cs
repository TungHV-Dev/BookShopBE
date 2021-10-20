using BookShopBE.Data.Dtos.Books;
using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Authors
{
    public class AuthorResponse<TDto> where TDto : BookDto
    {
        public AuthorDto authorDto { get; set; }
        public List<TDto> Dtos { get; set; }
    }
}
