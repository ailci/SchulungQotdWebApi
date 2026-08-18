using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Author;

public class AuthorForCreateDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}