using EasyGrocery.Domain.Repositories;
using EasyGrocery.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyGrocery.Infrastructure.Extensions
{
    public static class RegisterInfrastructureServices
    {
        public static IServiceCollection RegisterInfraServices(this IServiceCollection services)
        {
            //In-Memory data context
            services.AddDbContext<EasyDbContext>(options => options.UseInMemoryDatabase("EasyInMemoryDb"));

            services.AddScoped<EasyDbContext>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            return services;
        }
    }
}
