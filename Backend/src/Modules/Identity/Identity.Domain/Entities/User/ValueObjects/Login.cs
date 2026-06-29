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
        return new Login(value);
    }
}
