using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EasyGrocery.Application.Extensions
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {        
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
