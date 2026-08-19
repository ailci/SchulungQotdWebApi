using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Author;
using Application.Dto.Qotd;
using Application.Resolver;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteOfTheDayDto>();
        CreateMap<Author, AuthorDto>();

        CreateMap<AuthorForCreateDto, Author>()
            .ForMember(dest => dest.Photo,
                opt =>
                {
                    opt.PreCondition(c => c.Photo is not null);
                    opt.MapFrom<FormFileToByteArrayResolver>();
                })
            .ForMember(dest => dest.PhotoMimeType,
                opt =>
                {
                    opt.PreCondition(c => c.Photo is not null);
                    opt.MapFrom(src => src.Photo!.ContentType);
                });
    }
}