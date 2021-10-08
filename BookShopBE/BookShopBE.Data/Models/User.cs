using BookShopBE.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class User : ModelBase
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
