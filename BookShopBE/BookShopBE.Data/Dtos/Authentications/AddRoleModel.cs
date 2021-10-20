using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Dtos.Authentications
{
    public class AddRoleModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
