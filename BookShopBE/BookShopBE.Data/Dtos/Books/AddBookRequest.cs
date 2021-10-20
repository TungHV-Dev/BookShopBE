using BookShopBE.Common.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Books
{
    public class AddBookRequest : CreatedDto
    {
        public BookDto bookDto { get; set; }
        public bool IsAddAuthors { get; set; }
        public HashSet<int> AuthorIds { get; set; }
    }
}
