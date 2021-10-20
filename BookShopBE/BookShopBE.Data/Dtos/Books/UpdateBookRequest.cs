using BookShopBE.Common.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Books
{
    public class UpdateBookRequest : ModifiedDto
    {
        public int bookId { get; set; }
        public BookDto bookDto { get; set; }
        public bool IsUpdateAuthors { get; set; }
        public HashSet<int> AuthorIds { get; set; }
    }
}
