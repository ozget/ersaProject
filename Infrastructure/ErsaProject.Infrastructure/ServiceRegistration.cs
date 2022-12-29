
using ErsaProject.Application.Abstractions;
using ErsaProject.Application.Abstractions.Services;
using ErsaProject.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ErsaProject.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
