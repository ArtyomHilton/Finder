using Finder.Common.EF.Abstractions;
using Finder.Identity.Domain.Entities.User.ValueObjects;

namespace Finder.Identity.Domain.Entities.User;

public class User : IEntity<UserId>, IHaveTimestamp
{
    public UserId Id { get; private set; }

    public Login Login { get; private set; }
    public Password Password { get; private set; }
    public UserInfo Info { get; private set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    private User() { }
    private User(UserId id, Login login, Password password, UserInfo info)
    {
        Id = id;
        Login = login;
        Password = password;
        Info = info;
    }

    public static User Create(UserId id, Login login, Password password, UserInfo info)
    {
        return new User(id, login, password, info);
    }

    public void UpdateLogin(Login login)
    {
        Login = login;
    }

    public void UpdatePassword(Password password)
    {
        Password = password;
    }

    public void UpdateInfo(UserInfo info)
    {
        Info = info;
    }
}
