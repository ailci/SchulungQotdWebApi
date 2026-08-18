using Application.Dto.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto> GetAuthorAsync(Guid authorId);
    Task DeleteAuthorAsync(Guid authorId);
}