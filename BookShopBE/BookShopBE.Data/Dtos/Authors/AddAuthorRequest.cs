using BookShopBE.Common.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Dtos.Authors
{
    public class AddAuthorRequest : CreatedDto
    {
        public AuthorDto authorDto { get; set; }
        public bool IsAddOrUpdateBooks { get; set; }
        public HashSet<int> bookIds { get; set; }
    }
}
