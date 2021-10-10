using BookShopBE.Data.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
