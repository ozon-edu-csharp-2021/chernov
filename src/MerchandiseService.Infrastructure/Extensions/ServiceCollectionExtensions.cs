using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateMerchOrderCommandHandler).Assembly);
            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMerchOrderRepository, MerchOrderRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}