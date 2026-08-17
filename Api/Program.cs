using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //WebApi der Console hinzu
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline. #####################################################################
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("First middleware\n");
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


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
