using Application.Dto.Qotd;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Client.Pages;
    
public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public QuoteOfTheDayDto? QotdDto { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        logger.LogInformation($"{nameof(OnGet)} aufgerufen...");

        try
        {

        }
        catch (Exception e)
        {
            logger.LogError($"Ein Fehler ist aufgetreten {e.Message}");
            ErrorMessage = e.Message;
        }
    }
}