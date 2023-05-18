using Mc2.CrudTest.Infrastructure.EF;
using Mc2.CrudTest.Shared.Abstractions.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Queries;

namespace Mc2.CrudTest.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDB(configuration);
            services.AddQueries();
       
            return services;
        }
    }
}
