using USend.Domain.Interfaces;
using USend.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace USend.Infrastructure.IoC
{
    public static class Repositories
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
