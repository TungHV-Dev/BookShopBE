using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Books
{
    public class BookResponse : BookDto
    {
        public IEnumerable<string> AuthorNames { get; set; }
    }
    public class BookResponse<TDto> where TDto : class
    {
        public BookDto bookDto { get; set; }
        public IEnumerable<TDto> Dtos { get; set; }
    }
}
