using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;
using Application.Dto.Author;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdDbContext> contextFactory, IMapper mapper) : IAuthorService
{
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var authors = await context.Authors.AsNoTracking().ToListAsync();

        //1. Manuelles Mapping
        //return authors.Select(author => new AuthorDto
        //{
        //    Id = author.Id,
        //    Name = author.Name,
        //    Description = author.Description,
        //    BirthDate = author.BirthDate,
        //    Photo = author.Photo,
        //    PhotoMimeType = author.PhotoMimeType
        //});

        return mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} mit AuthorID: {authorId} aufgerufen...");

        var authorEntity = await GetAuthorAndCheckIfItExists(authorId);

        //return new AuthorDto
        //{
        //    Id = authorEntity.Id,
        //    Name = authorEntity.Name,
        //    Description = authorEntity.Description,
        //    BirthDate = authorEntity.BirthDate,
        //    Photo = authorEntity.Photo,
        //    PhotoMimeType = authorEntity.PhotoMimeType
        //};

        return mapper.Map<AuthorDto>(authorEntity);
    }

    public async Task DeleteAuthorAsync(Guid authorId)
    {
        logger.LogWarning($"{nameof(DeleteAuthorAsync)} wurde mit Author-Id {authorId} aufgerufen...");
        await using var context = await contextFactory.CreateDbContextAsync();
        
        var authorEntity = await GetAuthorAndCheckIfItExists(authorId);
        context.Authors.Remove(authorEntity);

        if (await context.SaveChangesAsync() != 1)
            throw new AuthorNotDeletedException(authorEntity.Name);

    }

    private async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        var author = await context.Authors.FindAsync(authorId);

        if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }
}