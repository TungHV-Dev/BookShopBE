using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
