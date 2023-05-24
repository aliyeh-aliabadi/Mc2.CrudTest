using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Commands;
using Mc2.CrudTest.Domain.Factories;

namespace Mc2.CrudTest.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ICustomerFactory, CustomerFactory>();

            return services;
        }
    }
}
