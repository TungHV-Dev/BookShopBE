using BookShopBE.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Dtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public float Rate { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
    }

    public class BookDto<TDto> : BookDto where TDto : CreateOrModifyDto
    {
        public TDto Dto { get; set; }
    }
}
