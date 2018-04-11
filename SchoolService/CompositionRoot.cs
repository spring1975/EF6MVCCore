using EF6;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolService
{
    public static class CompositionRoot
    {
        public static IServiceCollection AddServiceLayerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(_ => new SchoolContext(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
