using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public sealed class AuthorNotDeletedException(string message) : NotDeletedException($"The author with the name {message} could not be deleted in the db");