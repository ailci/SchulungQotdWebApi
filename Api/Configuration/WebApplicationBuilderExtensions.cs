using Api.Filter;
using Api.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Api.Configuration;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder AddWebApi()
        {
            builder.Services.AddControllers(); //WebApi der Console hinzu

            //builder.Services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter =
            //        true; //unterdrücke die standard rückgabe mit Badrequest in actions
            //});
            
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //Global Exception Handler
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            //Filter als Service registrieren
            builder.Services.AddScoped<TimeAsyncAttribute>();
            builder.Services.AddScoped<ApiKeyAuthFilter>();

            return builder;
        }
    }
}
