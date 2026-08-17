using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Middleware;

public enum Browser
{
    InternetExplorer,
    Firefox,
    Chrome,
    Edge,
    Opera,
    SomethingElse
}

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class BrowserAllowedMiddleware(RequestDelegate next, IEnumerable<Browser> browserAllowedList)
{
    public async Task Invoke(HttpContext httpContext)
    {
        var clientBrowserType = IdentifyBrowser(httpContext);

        if (browserAllowedList.Any(browser => browser == clientBrowserType))
        {
            //ERfolgfalls Browser in der WhiteList gefunden
            await next(httpContext);
        }
        else
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            httpContext.Response.ContentType = "text/html";
            await httpContext.Response.WriteAsync($"Der/Die Browser <strong>{clientBrowserType}</strong> wird leider nicht unterstuetzt. <a href=\"https://browsehappy.com\">BrowseHappy</a>", Encoding.UTF8);
        }
    }

    private Browser IdentifyBrowser(HttpContext httpContext)
    {
        var userAgent = httpContext.Request.Headers["User-Agent"][0]?.ToLower();
        Browser browser;

        if (userAgent.Contains("chrome") &&
            !(userAgent.Contains("edge") || userAgent.Contains("edg") || userAgent.Contains("opr")))
        {
            browser = Browser.Chrome;
        }
        else if (userAgent.Contains("firefox"))
        {
            browser = Browser.Firefox;
        }
        else if (userAgent.Contains("trident"))
        {
            browser = Browser.InternetExplorer;
        }
        else if (userAgent.Contains("edge") || userAgent.Contains("edg"))
        {
            browser = Browser.Edge;
        }
        else if (userAgent.Contains("opr"))
        {
            browser = Browser.Opera;
        }
        else
        {
            browser = Browser.SomethingElse;
        }

        return browser;
    }

}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class BrowserAllowedMiddlewareExtensions
{
    public static IApplicationBuilder UseBrowserAllowedMiddleware(this IApplicationBuilder builder, params IEnumerable<Browser> browserAllowedList)
    {
        return builder.UseMiddleware<BrowserAllowedMiddleware>(browserAllowedList);
    }
}