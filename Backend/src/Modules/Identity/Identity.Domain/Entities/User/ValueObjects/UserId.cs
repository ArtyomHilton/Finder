namespace Finder.Identity.Domain.Entities.User.ValueObjects;

public class UserId
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId Create() 
        => new UserId(Guid.CreateVersion7());

    public static UserId Create(Guid value) 
        => new UserId(value);
}
