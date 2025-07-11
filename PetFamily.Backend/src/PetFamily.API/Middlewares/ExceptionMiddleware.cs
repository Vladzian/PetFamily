using PetFamily.API.Middlewares;
using PetFamily.API.Response;
using System.Globalization;
using System.Net;

namespace PetFamily.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                //подготовка envelope для ответа в одном формате
                var responseError = new ResponseError("server.internal", ex.Message, null);
                var envelope = Envelope.Error([responseError]);

                //установки ответа
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //запись тела ответа
                await context.Response.WriteAsJsonAsync(envelope);
            }
        }
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}