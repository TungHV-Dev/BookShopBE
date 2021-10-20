using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
        public DateTime CreatedDate { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => RevokedDate == null && !IsExpired;
    }
}
