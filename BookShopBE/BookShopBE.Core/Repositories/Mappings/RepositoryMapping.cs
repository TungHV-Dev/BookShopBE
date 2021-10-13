using BookShopBE.Common.Repository;
using BookShopBE.Core.Repositories.Implementations;
using BookShopBE.Core.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopBE.Core.Repositories.Mappings
{
    public static class RepositoryMapping
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.InjectRepositoryBase();
            services.InjectRepository();
            return services;
        }

        private static IServiceCollection InjectRepositoryBase(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            return services;
        }

        private static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
