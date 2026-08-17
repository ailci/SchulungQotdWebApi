using Api.Configuration;
using Api.Middleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddWebApi();

var app = builder.Build();

// Configure the HTTP request pipeline. #####################################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0].ToLower(); 
//    await context.Response.WriteAsync($"First middleware {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("First Back middleware\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Second middleware\n");
//    await next();
//    await context.Response.WriteAsync("Second Back middleware\n");
//});
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});

//app.UseBrowserAllowedMiddleware(Browser.Chrome, Browser.Edge); //Custom Middleware

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
