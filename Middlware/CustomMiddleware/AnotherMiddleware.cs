using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnotherMiddleware
    {
        private readonly RequestDelegate _next;

        //constructor taking in RequestDelegate and taking it as dependency injection
        public AnotherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //middleware function
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("AnotherCustomMiddleware called\n\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("AnotherCustomMiddleware Finished\n\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnotherMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnotherMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherMiddleware>();
        }
    }
}
