using System;

namespace BookShopBE.Common.Dtos
{
    public class DtoBase
    {

    }

    public class CreateOrModifyDto 
    {

    }

    public class CreatedDto : CreateOrModifyDto
    {
        public DateTime CreatedDate => DateTime.Now;
        public string CreatedBy { get; set; }
    }

    public class ModifiedDto : CreateOrModifyDto
    {
        public DateTime ModifiedDate => DateTime.Now;
        public string ModifiedBy { get; set; }
    }
}
