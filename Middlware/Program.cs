//1. create an instance of web application builder
using Middlware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Register custom middleware as service
builder.Services.AddTransient<MyMiddleware>();

//2. app is calling Build() method, it returns web application which is ASP .Net Core
var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
    {
        await context.Response.WriteAsync("This is ASP .Net Core app");
        await next(context);
        //Code
    }
);

//Middleware 2
app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("\n\n");
        await next(context);
    }
);

//Middleware 3 / custom middleware
//app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();

//Middleware 4
app.Run(async (HttpContext context) =>
    {
        await context.Response.WriteAsync("This is ASP .Net Core app 222\n\n");
    }
);


//starts the server, where this ASP .Net Core is hosted
app.Run();