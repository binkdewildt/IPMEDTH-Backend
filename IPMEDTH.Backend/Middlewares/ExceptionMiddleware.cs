using IPMEDTH.Backend.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Net;

namespace IPMEDTH.Backend.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Something went wrong with the database: {ex}");

                string exMessage = ex.InnerException is MySqlException sqlException ? sqlException.Message : ex.Message;
                await HandleExceptionAsync(httpContext, ex.InnerException ?? ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            await context.Response.WriteAsync(new ErrorDTO()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }

        private static int GetStatusCode(Exception exception)
        {
            if (exception is BadHttpRequestException)
                return (int)HttpStatusCode.BadRequest;
            else if (exception is UnauthorizedAccessException)
                return (int)HttpStatusCode.Unauthorized;
            else if (exception is NotImplementedException)
                return (int)HttpStatusCode.NotImplemented;

            return (int)HttpStatusCode.InternalServerError;
        }
    }
}
