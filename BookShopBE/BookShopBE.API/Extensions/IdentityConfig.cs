using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.API.Extensions
{
    public static class IdentityConfig
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookShopDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
