using Application.Dto.Qotd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]  //localhost:1234/api/qotd
[ApiController]
public class QotdController(ILogger<QotdController> logger) : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<QuoteOfTheDayDto> GetQuoteOfTheDay()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDay)} aufgerufen...");

        var qotdDto = new QuoteOfTheDayDto
        {
            Id = Guid.NewGuid(),
            AuthorName = "Ali Ilci",
            AuthorDescription = "Dozent",
            AuthorBirthDate = new DateOnly(1978, 07, 13),
            QuoteText = "Larum lierum Löffelstiel"
        };

        return qotdDto;
    }
}