using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filter;

public class ApiKeyAuthFilter : IAuthorizationFilter
{
    private const string ApiKeyName = "x-api-key";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //1. Fehlerfall ApiKey fehlt
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var apiKeyToValidate))
        {
            context.Result = new UnauthorizedObjectResult(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurred",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Api Key fehlt!"
            });
            return;
        }
    }
}