using Application.Dto.Qotd;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]  //localhost:1234/api/qotd
[ApiController]
public class QotdController(ILogger<QotdController> logger, QotdDbContext context) : ControllerBase
{
    /// <summary>
    /// Retrieves the quote ofthe day
    /// </summary>
    /// <returns>qotdDto</returns>
    /// <returns>qotdDto</returns>
    [HttpGet]  //=> localhost:1234/api/qotd
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuoteOfTheDayDto>> GetQuoteOfTheDay()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDay)} aufgerufen...");

        var quotes = await context.Quotes.Include(c => c.Author).AsNoTracking().ToListAsync();
        var randomQuote = quotes.Shuffle().First();

        var qotdDto = new QuoteOfTheDayDto
        {
            Id = randomQuote.Id,
            AuthorName = randomQuote.Author?.Name ?? string.Empty,
            AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
            QuoteText = randomQuote.QuoteText
        };

        return Ok(qotdDto);
    }
}