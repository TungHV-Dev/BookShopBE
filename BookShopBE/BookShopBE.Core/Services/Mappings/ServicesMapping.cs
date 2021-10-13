using BookShopBE.Core.Services.Implementations;
using BookShopBE.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.Core.Services.Mappings
{
    public static class ServicesMapping
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<IFeedbackServices, FeedbackServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            return services;
        }
    }
}
