using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Author;

public class AuthorDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public byte[]? Photo { get; set; }
    public string? PhotoMimeType { get; set; }
}