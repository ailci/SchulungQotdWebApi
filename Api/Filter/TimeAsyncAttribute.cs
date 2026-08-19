using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filter;

//Achtung in IServiceCollection registrieren
public class TimeAsyncAttribute(ILogger<TimeAsyncAttribute> logger) : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var sw = Stopwatch.StartNew();

        await next();

        sw.Stop();
        
        var elapsedMilliseconds = sw.ElapsedMilliseconds;
        var controller = (ControllerBase) context.Controller;
        logger.LogInformation($"Verstrichene Zeit: {elapsedMilliseconds}ms, {controller.Request.Method} {controller.Request.GetEncodedUrl()}");
    }
}