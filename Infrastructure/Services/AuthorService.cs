using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Application.Dto.Author;

namespace Infrastructure.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdDbContext> contextFactory) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var authors = await context.Authors.AsNoTracking().ToListAsync();

        //1. Manuelles Mapping
        return authors.Select(author => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        });
    }
}