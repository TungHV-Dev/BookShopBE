using System;

namespace BookShopBE.Common.Dtos
{
    public class CreatedDto
    {
        public DateTime CreatedDate => DateTime.Now;
        public string CreatedBy { get; set; }
    }

    public class ModifiedDto
    {
        public DateTime ModifiedDate => DateTime.Now;
        public string ModifiedBy { get; set; }
    }
}
