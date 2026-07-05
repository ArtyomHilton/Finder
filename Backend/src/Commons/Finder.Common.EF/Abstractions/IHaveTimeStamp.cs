namespace Finder.Common.EF.Abstractions;

public interface IHaveTimestamp
{
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}