using Application.Contracts.Services;
using Application.Dto.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")] // localhost:1234/api/authors
[ApiController]
public class AuthorsController(ILogger<AuthorsController> logger, IServiceManager serviceManager) : ControllerBase
{
    #region GET

    [HttpGet]
    [ProducesResponseType<IEnumerable<AuthorDto>>(StatusCodes.Status200OK, Description = "The authors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAuthors()
    {
        logger.LogInformation($"{nameof(GetAuthors)} aufgerufen...");

        return Ok(await serviceManager.AuthorService.GetAuthorsAsync());
    }


    [HttpGet("{id:guid}", Name = "GetAuthor")]  // localhost:1234/api/authors/{id}
    [ProducesResponseType<AuthorDto>(StatusCodes.Status200OK, Description = "The authors")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        logger.LogInformation($"{nameof(GetAuthor)} mit AuthorId: {id} aufgerufen...");

        var authorDto = await serviceManager.AuthorService.GetAuthorAsync(id);

        if (authorDto is null) return NotFound();

        return Ok(authorDto);
    }

    #endregion

    #region DELETE

    /// <summary>
    /// Deletes an author
    /// </summary>
    /// <param name="authorId">the unique identifer of the author to delete</param>
    /// <returns>if the author was successfully deleted</returns>
    [HttpDelete("{authorId:guid}", Name = "DeleteAuthor")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> DeleteAuthor(Guid authorId)
    {
        logger.LogInformation($"{nameof(GetAuthor)} mit AuthorId: {authorId} aufgerufen...");
        await serviceManager.AuthorService.DeleteAuthorAsync(authorId);

        return NoContent();
    }

    #endregion
}