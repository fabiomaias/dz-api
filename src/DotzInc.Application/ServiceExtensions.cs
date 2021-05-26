using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using DotzInc.Application.Conduct;
using System.Reflection;
using DotzInc.Application.Interfaces;
using DotzInc.Application.LocalServices;

namespace DotzInc.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IConversionService, ConversionService>();
        }
    }
}
