using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Qotd;

namespace Application.Contracts.Services;

public interface IQotdService
{
    Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync();
    Task<QuoteOfTheDayDto> GetQuoteOfTheDaySecuredAsync();
}