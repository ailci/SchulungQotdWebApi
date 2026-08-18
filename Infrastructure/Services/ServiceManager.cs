using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Services;

namespace Infrastructure.Services;

public class ServiceManager(IQotdService qotdService) : IServiceManager
{
    public IQotdService QotdService => qotdService;
}