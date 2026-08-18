using Application.Contracts.Services;
using Application.Dto.Qotd;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]  //localhost:1234/api/qotd
[ApiController]
public class QotdController(ILogger<QotdController> logger, IServiceManager serviceManager) : ControllerBase
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

        var qotdDto = await serviceManager.QotdService.GetQuoteOfTheDayAsync();

        return Ok(qotdDto);
    }
}