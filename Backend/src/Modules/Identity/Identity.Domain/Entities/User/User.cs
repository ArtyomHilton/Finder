using Finder.Identity.Domain.Entities.Abstractions;
using Finder.Identity.Domain.Entities.User.ValueObjects;

namespace Finder.Identity.Domain.Entities.User;

public class User : IEntity<UserId>
{
    public UserId Id { get; private set; }

    public Login Login { get; private set; }

    private User(UserId id, Login login)
    {
        Id = id;
        Login = login;
    }

    public static User Create(UserId id, Login login)
    {
        return new User(id, login);
    }
}
