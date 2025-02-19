using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EasyGrocery.Api.Extensions
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
                _logger.LogError(
                    exception, "Exception occurred: {Message}", exception.Message);
            
            if (exception.GetType().Name.Equals("ValidationException"))
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = exception.Message
                };
                httpContext.Response.StatusCode = problemDetails.Status.Value;
                await httpContext.Response
                    .WriteAsJsonAsync(problemDetails, cancellationToken);
            }
            else
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server error"
                };
                httpContext.Response.StatusCode = problemDetails.Status.Value;
                await httpContext.Response
                    .WriteAsJsonAsync(problemDetails, cancellationToken);
            }
            return true;
        }
    }
}
