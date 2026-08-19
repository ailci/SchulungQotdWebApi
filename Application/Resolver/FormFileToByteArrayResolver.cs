using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Author;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Resolver;

public class FormFileToByteArrayResolver : IValueResolver<AuthorForCreateDto, Author, byte[]?>
{
    public byte[]? Resolve(AuthorForCreateDto source, Author destination, byte[]? destMember, ResolutionContext context)
    {
        return ConvertFileToByteArray(source.Photo);
    }

    private byte[]? ConvertFileToByteArray(IFormFile? file)
    {
        ArgumentNullException.ThrowIfNull(file);

        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}