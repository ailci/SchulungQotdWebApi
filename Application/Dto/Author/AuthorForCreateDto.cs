using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Application.Validations;
using Microsoft.AspNetCore.Http;

namespace Application.Dto.Author;

public class AuthorForCreateDto
{
    [Required(ErrorMessage = "Bitte geben Sie einen Namen ein")]
    [MaxLength(150, ErrorMessage = "Der Name darf 150 Zeichen nicht überschreiten")]
    [DeniedValues("administrator","admin","root","god", ErrorMessage = "Der Name ist nicht erlaubt")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein")]
    public required string Description { get; set; }

    [NoFutureDate(ErrorMessage = "Geburtsdatum liegt in der Zukunft")]
    public DateOnly? BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}