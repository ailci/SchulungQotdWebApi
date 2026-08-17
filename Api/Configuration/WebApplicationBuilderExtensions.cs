namespace Api.Configuration;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder AddWebApi()
        {
            builder.Services.AddControllers(); //WebApi der Console hinzu
            
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            return builder;
        }
    }
}
