using Microsoft.Extensions.DependencyInjection;
using PDVAplication.Domain.Requests.Command;
using PDVAplication.Domain.Requests.Query;

namespace PDVAplications.Ioc.Dependeces
{
    public static class MediatRExtesion
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(CreateMembroRequest).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCustomerCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CustomerGetByIdQuery).Assembly));
        }
    }
}
