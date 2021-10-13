using BookShopBE.Common.Dtos;
using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Requests
{
    public class AuthorRequest
    {
        public AuthorDto authorDto { get; set; }
        public bool IsAddOrUpdateBooks { get; set; }
        public HashSet<int> bookIds { get; set; }
    }

    public class AuthorRequest<TDto> where TDto : CreateOrModifyDto
    {
        public AuthorDto<TDto> authorDto { get; set; }
        public bool IsAddOrUpdateBooks { get; set; }
        public HashSet<int> bookIds { get; set; }
    }
}
