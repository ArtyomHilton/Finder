using System.Text.RegularExpressions;
using Finder.Identity.Domain.Exceptions;

namespace Finder.Identity.Domain.Entities.User.ValueObjects;

public class Login
{
    public string Value { get; private set; }

    private Login(string value)
    {
        Value = value;
    }

    public static Login Create(string value)
    {
        if (value.Length < DomainRules.User.Login.MinLength || value.Length > DomainRules.User.Login.MaxLength)
            throw new DomainException(DomainMessages.User.Login.LoginLengthNotCorrect, nameof(Login));

        if (!Regex.IsMatch(value, DomainRules.User.Login.Regex))
            throw new DomainException(DomainMessages.User.Login.LoginNotCorrectFormat, nameof(Login));

        return new Login(value);
    }
}
