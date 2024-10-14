using Ecommerce.Application.Common.Behaviours;
using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application
{
    public static class RegisterApplicationDependencies
    {
        public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
        {
            // Add MediaR in DI contianer
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            // Add Services to DI Contianer
            services.AddScoped<IProductServices, ProductServices>();


            return services;
        }
    }
}
