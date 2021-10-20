using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopBE.Data.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "398dce1a-e3fb-4ff3-ab8b-57a2484ebe36",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "877c6664-a64b-4656-9b62-603867a648c8",
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            }
            );
        }
    }
}
