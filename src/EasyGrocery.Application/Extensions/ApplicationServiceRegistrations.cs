using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Behaviors;
using System.Reflection;

namespace EasyGrocery.Application.Extensions
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
