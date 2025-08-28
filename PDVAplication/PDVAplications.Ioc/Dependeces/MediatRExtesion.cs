using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using PDVAplication.Domain.Requests.Query.CustomerQuery;
using PDVAplication.Domain.Requests.Query.ProductQuery;

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
        }
    }
}
