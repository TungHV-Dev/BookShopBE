using BookShopBE.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Dtos
{
    public class StoreDto : DtoBase
    {
        [Required(ErrorMessage = "Store 's name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is invalid")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }

    public class StoreDto<TDto> : StoreDto where TDto : CreateOrModifyDto
    {
        public TDto Dto { get; set; }
    }
}
