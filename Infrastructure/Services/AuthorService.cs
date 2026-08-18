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

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} mit AuthorID: {authorId} aufgerufen...");
        await using var context = await contextFactory.CreateDbContextAsync();

        //var author = await context.Authors.Where(c => c.Id == authorId);
        //var author = await context.Authors.FirstOrDefaultAsync(c => c.Id == authorId);
        //var author = await context.Authors.SingleOrDefaultAsync(c => c.Id == authorId);
        var author = await context.Authors.FindAsync(authorId);

        if (author is null) return null;

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        };
    }
}