
namespace Middlware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Before logic
            await context.Response.WriteAsync("Custom middleware started!\n\n");

            await next(context);

            //After logic
            await context.Response.WriteAsync("Custom middleware finished!\n\n");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
