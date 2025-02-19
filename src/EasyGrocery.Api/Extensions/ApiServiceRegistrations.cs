using EasyGrocery.Application.Extensions;
using EasyGrocery.Infrastructure.Extensions;

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
                        
            return builder;
        }
    }
}
