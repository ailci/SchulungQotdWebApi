using Application;
using Microsoft.Extensions.Options;

namespace UI.Client.Handler;

public class ApiKeyDelegatingHandler(IOptions<QotdAppSettings> appSettings) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //Vor Abschicken der Anfrage Api Key hinzufügen
        request.Headers.Add("x-api-key", appSettings.Value.XApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}