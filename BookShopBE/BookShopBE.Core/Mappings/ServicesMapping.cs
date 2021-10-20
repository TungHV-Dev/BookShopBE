using BookShopBE.Core.Services.Implementations;
using BookShopBE.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.Core.Mappings
{
    public static class ServicesMapping
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<IFeedbackServices, FeedbackServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IUserServices, UserServices>();

            return services;
        }
    }
}
