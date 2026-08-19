using Application;
using Application.Contracts.Services;
using Microsoft.Extensions.Options;
using Refit;
using UI.Client.Handler;
using UI.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddApplicationServices();

//AppSettings
var qotdAppSettings = builder.Configuration.GetSection(nameof(QotdAppSettings)).Get<QotdAppSettings>();
builder.Services.Configure<QotdAppSettings>(builder.Configuration.GetSection(nameof(QotdAppSettings))); //Options Pattern

//DI
builder.Services.AddScoped<IQotdService, QotdApiService>();
builder.Services.AddScoped<IAuthorService, AuthorApiService>();
builder.Services.AddTransient<ApiKeyDelegatingHandler>();

//Named Client
builder.Services.AddHttpClient("qotdapiservice", (sp, configure) =>
{
    configure.BaseAddress = new Uri(qotdAppSettings?.QotdServiceApiUri!);

    //Alternative
    //var apiSettings = sp.GetRequiredService<IOptions<QotdAppSettings>>().Value;
    //configure.BaseAddress = new Uri(apiSettings?.QotdServiceApiUri!);

    //configure.BaseAddress = new Uri("https://localhost:7031");
    configure.DefaultRequestHeaders.Add("Accept","application/json");
}).AddHttpMessageHandler<ApiKeyDelegatingHandler>();


//Refit Client
builder.Services.AddRefitClient<IQotdRefitService>()
    .ConfigureHttpClient((sp, configure) =>
    {
        var apiSettings = sp.GetRequiredService<IOptions<QotdAppSettings>>().Value;
        configure.BaseAddress = new Uri(apiSettings?.QotdServiceApiUri!);
        configure.DefaultRequestHeaders.Add("Accept", "application/json");
    }).AddHttpMessageHandler<ApiKeyDelegatingHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline. #################################################################
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
