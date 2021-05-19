using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace USend.Infrastructure.IoC
{
    public static class AutoMapper
    {
        public static void RegisterAutoMapper(this IServiceCollection services, IMapper mapper)
        {
            services.AddSingleton(mapper);
        }
    }
}
