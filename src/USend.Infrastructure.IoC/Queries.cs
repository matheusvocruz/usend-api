using USend.Application.Interfaces;
using USend.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace USend.Infrastructure.IoC
{
    public static class Queries
    {
        public static void RegisterQueries(this IServiceCollection services)
        {
            services.AddScoped<IUserQueries, UserQueries>();
        }
    }
}
