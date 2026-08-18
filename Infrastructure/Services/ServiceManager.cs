using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;

namespace Infrastructure.Services;

public class ServiceManager(IQotdService qotdService, IAuthorService authorService) : IServiceManager
{
    public IQotdService QotdService => qotdService;
    public IAuthorService AuthorService => authorService;
}