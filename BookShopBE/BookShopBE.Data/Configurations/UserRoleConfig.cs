using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopBE.Data.Configurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "em824cm3-pa26-12e1-b7dc-95kj7f3m2586",
                RoleId = "398dce1a-e3fb-4ff3-ab8b-57a2484ebe36"
            },
            new IdentityUserRole<string>
            {
                UserId = "ab4774d0-ec0a-2tfc-rm48-fadd274265pe",
                RoleId = "877c6664-a64b-4656-9b62-603867a648c8"
            }
            );
        }
    }
}
