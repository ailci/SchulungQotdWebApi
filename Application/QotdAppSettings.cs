using System;
using System.Collections.Generic;
using System.Text;

namespace Application;

public class QotdAppSettings
{
    public required string QotdServiceApiUri { get; init; }
    public required string XApiKey { get; init; }
}