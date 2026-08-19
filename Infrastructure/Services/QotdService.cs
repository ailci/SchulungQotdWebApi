using Application.Contracts.Services;
using Application.Dto.Qotd;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Infrastructure.Services;

public class QotdService(ILogger<QotdService> logger, IDbContextFactory<QotdDbContext> contextFactory, IMapper mapper) : IQotdService
{
    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();

        var quotes = await context.Quotes.Include(c => c.Author).AsNoTracking().ToListAsync();
        var randomQuote = quotes.Shuffle().First();

        //Manulles Mapping
        //return new QuoteOfTheDayDto
        //{
        //    Id = randomQuote.Id,
        //    AuthorName = randomQuote.Author?.Name ?? string.Empty,
        //    AuthorDescription = randomQuote.Author?.Description ?? string.Empty,
        //    AuthorBirthDate = randomQuote.Author?.BirthDate,
        //    AuthorPhoto = randomQuote.Author?.Photo,
        //    AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
        //    QuoteText = randomQuote.QuoteText
        //};

        //Automapper
        return mapper.Map<QuoteOfTheDayDto>(randomQuote);
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDaySecuredAsync()
    {
        return await GetQuoteOfTheDayAsync();
    }
}