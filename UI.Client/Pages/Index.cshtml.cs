using System.Text.Json;
using Application.Dto.Qotd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Client.Pages;
    
public class IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory) : PageModel
{
    public QuoteOfTheDayDto? QotdDto { get; set; }
    public string? ErrorMessage { get; set; }

    public async Task OnGet()
    {
        logger.LogInformation($"{nameof(OnGet)} aufgerufen...");

        try
        {
            //1. Klassiker
            //var client = httpClientFactory.CreateClient("qotdapiservice");
            //var response = await client.GetAsync("api/qotd"); // BaseAdresse + api/qotd
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //logger.LogInformation($"Rückgabe vom Server: {content}");
            //QotdDto = JsonSerializer.Deserialize<QuoteOfTheDayDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            //2. Abkürzung
            var client = httpClientFactory.CreateClient("qotdapiservice");
            QotdDto = await client.GetFromJsonAsync<QuoteOfTheDayDto>("api/qotd");

            //3. Als Service

        }
        catch (HttpRequestException e)
        {
            logger.LogError($"Ein Fehler ist aufgetreten {e.Message} {e.StatusCode}");
            ErrorMessage = $"{e.StatusCode} {e.Message}";
        }
    }
}