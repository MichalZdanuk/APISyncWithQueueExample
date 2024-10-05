using Shared.Exceptions;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace SystemA.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly string InternalErrorMessage = "Internal Server Error";
        public ExceptionHandlingMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ForbiddenException => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError,
            };

            var errorMessage = httpContext.Response.StatusCode == StatusCodes.Status500InternalServerError
                ? InternalErrorMessage
                : exception.Message;

            var response = new
            {
                statusCode = httpContext.Response.StatusCode,
                errorMessage = errorMessage
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
