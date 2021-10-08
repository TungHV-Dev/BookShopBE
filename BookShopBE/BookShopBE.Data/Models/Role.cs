using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Data.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Detail { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
