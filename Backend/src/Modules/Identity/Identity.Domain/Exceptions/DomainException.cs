namespace Finder.Identity.Domain.Exceptions;

public class DomainException : Exception
{
    public string ObjectName { get; init; }

    public DomainException(string message, string objectName) : base(message) 
    {
        ObjectName = objectName;
    }
}
