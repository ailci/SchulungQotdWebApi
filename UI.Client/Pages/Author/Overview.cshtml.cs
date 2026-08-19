using Application.Contracts.Services;
using Application.Dto.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Client.Pages.Author;

public class OverviewModel(ILogger<OverviewModel> logger, IAuthorService apiAuthorService) : PageModel
{
    public IEnumerable<AuthorDto>? AuthorDtos { get; set; }

    public async Task OnGet()
    {
        try
        {
            AuthorDtos = (await apiAuthorService.GetAuthorsAsync()).OrderBy(c => c.Name);
        }
        catch (HttpRequestException e)
        {
            logger.LogError($"{e.StatusCode} ## {e.Message}");
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
        }
    }
}