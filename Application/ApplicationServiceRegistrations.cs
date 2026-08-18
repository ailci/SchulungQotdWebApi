using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Automapper
        services.AddAutoMapper(config => { }, AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}