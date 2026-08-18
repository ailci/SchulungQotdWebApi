using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);