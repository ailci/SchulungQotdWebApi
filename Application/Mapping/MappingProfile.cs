using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Author;
using Application.Dto.Qotd;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteOfTheDayDto>();
        CreateMap<Author, AuthorDto>();
    }
}