using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Common.Dtos
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
