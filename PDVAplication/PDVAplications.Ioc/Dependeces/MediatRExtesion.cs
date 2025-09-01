using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using PDVAplication.Domain.Requests.Command.SaleCommands;
using PDVAplication.Domain.Requests.Query.CustomerQuery;
using PDVAplication.Domain.Requests.Query.ProductQuery;
using PDVAplication.Domain.Requests.Query.SaleQuery;

namespace PDVAplications.Ioc.Dependeces
{
    public static class MediatRExtesion
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(CreateMembroRequest).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCustomerCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CustomerGetByIdQuery).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ProductGetAllQuery).Assembly));
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SaleGetAllQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateSaleCommand).Assembly));

        }
    }
}
