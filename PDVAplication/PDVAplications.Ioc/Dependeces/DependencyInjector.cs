using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Data.Repositories;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Services.Services;
using PDVAplication.Services.Services.Interface;

namespace PDVAplications.Ioc.Dependeces
{
    public static class DependencyInjector
    {
        public static void AddDepencies(this IServiceCollection services)
        {
            AddRepositoryDependency(services);
        }

        private static void AddRepositoryDependency(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
