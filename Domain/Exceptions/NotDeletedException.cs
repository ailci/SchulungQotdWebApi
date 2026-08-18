using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public abstract class NotDeletedException(string message) : Exception(message);
