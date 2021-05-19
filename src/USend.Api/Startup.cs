using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using USend.Infrastructure.IoC;
using AutoMapper;
using USend.Api.Configuration.ApiConfig;
using USend.Api.Configuration.Mapper;

namespace USend.Api
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration config, IHostEnvironment hostEnvironment)
        {
            _configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.RegisterAutoMapper(mapper);
            services.RegisterRepositories();
            services.RegisterQueries();
            services.RegisterContexts(_configuration);
            services.RegisterMediator();
            services.RegisterApiVersion();
            services.RegisterSwaggerConfig();
            services.RegisterAuthConfig();

            services.AddApiConfiguration(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfig();
            }

            //ApiConfig
            app.UseApiConfiguration();
        }
    }
}
