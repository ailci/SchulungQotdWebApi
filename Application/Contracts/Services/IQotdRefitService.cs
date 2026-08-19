using Application.Dto.Qotd;
using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace Application.Contracts.Services;

public interface IQotdRefitService
{
    [Get("/api/qotd")] //Refit Attribute für HTTP Request
    Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync(); 
    
    [Get("/api/qotd/secured")] //Refit Attribute für HTTP Request
    Task<QuoteOfTheDayDto> GetQuoteOfTheDaySecuredAsync();
}