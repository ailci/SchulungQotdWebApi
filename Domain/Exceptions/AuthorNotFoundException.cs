using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions;

public sealed class AuthorNotFoundException(Guid authorId) : NotFoundException($"The author with: {authorId} does not exist in the database");