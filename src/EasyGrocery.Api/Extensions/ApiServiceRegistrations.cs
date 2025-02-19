using EasyGrocery.Application.Extensions;
using EasyGrocery.Infrastructure.Extensions;
using System.Reflection;

namespace EasyGrocery.Api.Extensions
{
    public static class ApiServiceRegistrations
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //Infra
            builder.Services.RegisterInfraServices();

            //Application
            builder.Services.RegisterAppServices();

            //Global Exception Handling
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Mapper
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}
