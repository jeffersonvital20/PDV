using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Data.Repositories;
using PDVAplication.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
