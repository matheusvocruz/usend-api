using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using USend.Application.Pipes;
using FluentValidation;

namespace USend.Infrastructure.IoC
{
    public static class Mediator
    {
        public static void RegisterMediator(this IServiceCollection services)
        {
            const string applicationAssemblyName = "USend.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}
