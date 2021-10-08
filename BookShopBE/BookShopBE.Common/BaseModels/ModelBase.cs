using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopBE.Common.BaseModels
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
