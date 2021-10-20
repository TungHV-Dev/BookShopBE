using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BookShopBE.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            User admin = new User
            {
                Id = "em824cm3-pa26-12e1-b7dc-95kj7f3m2586",
                FirstName = "Admin",
                LastName = "1",
                UserName = "admin",
                PhoneNumber = "0912345678",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN1@GMAIL.COM",
                DateOfBirth = new DateTime(1990, 01, 01),
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "Admin@123")
            };

            User customer = new User
            {
                Id = "ab4774d0-ec0a-2tfc-rm48-fadd274265pe",
                FirstName = "Customer",
                LastName = "1",
                UserName = "customer",
                PhoneNumber = "0123456789",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "CUSTOMER1@GMAIL.COM",
                DateOfBirth = new DateTime(1999, 01, 01),
                NormalizedUserName = "CUSTOMER  ",
                PasswordHash = hasher.HashPassword(null, "Customer@123")
            };
            builder.HasData(admin, customer);
        }
    }
}
