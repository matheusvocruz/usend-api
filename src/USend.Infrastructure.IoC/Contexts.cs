using USend.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace USend.Infrastructure.IoC
{
    public static class Contexts
    {
        public static void RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<USendContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, USendContext>();
        }
    }
}
