using Finder.Identity.Domain.Exceptions;

namespace Finder.Identity.Domain.Entities.User.ValueObjects;

public class Password
{
    public string Value { get; private set; } = null!;

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new DomainException(DomainMessages.User.Password.PasswordCannotBeEmpty, nameof(Password));

        return new Password(password);
    }
}
