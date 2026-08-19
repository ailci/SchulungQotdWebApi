using Application;
using Application.Contracts.Services;
using Application.Dto.Author;
using Microsoft.Extensions.Options;

namespace UI.Client.Services;

public class AuthorApiService(ILogger<AuthorApiService> logger, IOptions<QotdAppSettings> appSettings, IHttpClientFactory httpClientFactory) : IAuthorService
{
    private const string QotdAuthorsUri = "api/authors";

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} API aufgerufen...");

        var client = httpClientFactory.CreateClient("qotdapiservice");

        return await client.GetFromJsonAsync<IEnumerable<AuthorDto>>(QotdAuthorsUri);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(DeleteAuthorAsync)} API aufgerufen...");

        var client = httpClientFactory.CreateClient("qotdapiservice");

        var response = await client.DeleteAsync($"{QotdAuthorsUri}/{authorId}"); // api/authors/{authorId}

        if (response is null) throw new HttpRequestException("Response is null");
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto)
    {
        throw new NotImplementedException();
    }
}