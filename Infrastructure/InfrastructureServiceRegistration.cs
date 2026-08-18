using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        //QotdDbContext
        services.AddDbContext<QotdDbContext>(options =>
        {
            options
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);

            options.EnableSensitiveDataLogging();
        });

        //DI Services
        services.AddScoped<IQotdService, QotdService>();
        services.AddScoped<IServiceManager, ServiceManager>();

        return services;
    }
}