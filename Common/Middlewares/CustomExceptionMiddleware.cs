using Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Common.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is BadRequestException)
                return WriteResponse(context, exception, HttpStatusCode.BadRequest);
            else if (exception is ForbiddenException)
                return WriteResponse(context, exception, HttpStatusCode.Forbidden);
            else
                return WriteResponse(context, exception, HttpStatusCode.InternalServerError);
        }

        static Task WriteResponse(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var result = new ContentResult()
            {
                ContentType = "application/json",
                Content = exception.Message,
                StatusCode = (int)code
            };
            return context.Response.WriteAsJsonAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<CustomExceptionMiddleware>();
    }
}
