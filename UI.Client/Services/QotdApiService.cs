using Application;
using Application.Contracts.Services;
using Application.Dto.Qotd;
using Microsoft.Extensions.Options;

namespace UI.Client.Services;

public class QotdApiService(ILogger<QotdApiService> logger, IHttpClientFactory httpClientFactory, IOptions<QotdAppSettings> appSettings) : IQotdService
{
    private readonly QotdAppSettings _appSettings = appSettings.Value;
    private const string QotdUri = "api/qotd";
    private const string QotdSecuredUri = "api/qotd/secured";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} API aufgerufen...");
        
        var client = httpClientFactory.CreateClient("qotdapiservice");
        
        var response = await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);

        return response ?? throw new HttpRequestException("Response is null");
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDaySecuredAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDaySecuredAsync)} API aufgerufen...");

        var client = httpClientFactory.CreateClient("qotdapiservice");

        client.DefaultRequestHeaders.Add("x-api-key",_appSettings.XApiKey);

        var response = await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdSecuredUri);

        return response ?? throw new HttpRequestException("Response is null");
    }
}