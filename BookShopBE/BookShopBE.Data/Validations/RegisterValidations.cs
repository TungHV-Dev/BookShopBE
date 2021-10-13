using BookShopBE.Data.Dtos;
using BookShopBE.Data.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.Data.Validations
{
    public static class RegisterValidations
    {
        public static IServiceCollection RegisterModelValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AuthorDto>, AuthorValidator>();
            services.AddTransient<IValidator<BookDto>, BookValidator>();
            services.AddTransient<IValidator<Customer>, CustomerValidator>();
            services.AddTransient<IValidator<StoreDto>, StoreValidator>();
            return services;
        }
    }
}
