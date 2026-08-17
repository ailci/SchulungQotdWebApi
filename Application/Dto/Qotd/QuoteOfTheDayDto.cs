using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Qotd;

public class QuoteOfTheDayDto
{
    public Guid Id { get; init; }
    public required string AuthorName { get; init; }
    public required string AuthorDescription { get; init; }
    public DateOnly? AuthorBirthDate { get; init; }
    public byte[]? AuthorPhoto { get; init; }
    public string? AuthorPhotoMimeType { get; init; }
    public required string QuoteText { get; init; }
}