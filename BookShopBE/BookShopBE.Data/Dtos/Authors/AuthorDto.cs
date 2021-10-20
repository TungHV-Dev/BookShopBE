using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Dtos.Authors
{
    public class AuthorDto
    {
        [Required(ErrorMessage = "Author 's name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is invalid")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        public string Description { get; set; }
    }
}
