using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public abstract class NotCreatedException(string message) : Exception(message);