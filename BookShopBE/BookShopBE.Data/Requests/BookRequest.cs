using BookShopBE.Common.Dtos;
using BookShopBE.Data.Dtos;
using System.Collections.Generic;

namespace BookShopBE.Data.Requests
{
    public class BookRequest
    {
        public BookDto bookDto { get; set; }
        public bool IsAddOrUpdateAuthors { get; set; }
        public bool IsAddOrUpdateStores { get; set; }
        public HashSet<int> AuthorIds { get; set; }
        public HashSet<int> StoreIds { get; set; }
    }

    public class BookRequest<TDto> where TDto : CreateOrModifyDto
    {
        public BookDto<TDto> bookDto { get; set; }
        public bool IsAddOrUpdateAuthors { get; set; }
        public bool IsAddOrUpdateStores { get; set; }
        public HashSet<int> AuthorIds { get; set; }
        public HashSet<int> StoreIds { get; set; }
    }
}
