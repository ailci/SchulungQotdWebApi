namespace Domain.Exceptions
{
    [Serializable]
    public sealed class AuthorNotCreatedException(string? message) : NotCreatedException($"The author with the name: {message} could not be created in the database.");
}