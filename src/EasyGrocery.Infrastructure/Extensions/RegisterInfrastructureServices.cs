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
            services.AddDbContext<SqlDbContext>(options =>
                                  options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EasyGroceryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            services.AddScoped<SqlDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
