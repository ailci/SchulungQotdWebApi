using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Services;

public interface IServiceManager
{
    IQotdService QotdService { get; }
    IAuthorService AuthorService { get; }
}