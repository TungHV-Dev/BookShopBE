using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Dtos.Feedbacks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.Data.Validations
{
    public static class RegisterValidations
    {
        public static IServiceCollection RegisterModelValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BookDto>, BookValidator>();
            services.AddTransient<IValidator<FeedbackMessageDto>, FeedbackMessageDtoValidator>();
            services.AddTransient<IValidator<RateStarDto>, RateStarDtoValidator>();

            return services;
        }
    }
}
