using Microsoft.Extensions.DependencyInjection;
using SchoolService;
using SchoolService.Interfaces;

namespace MVCCore
{
    public static class CompositeRoot
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }

    }
}
