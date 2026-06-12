namespace Finder.Common.EF.Abstractions;

public interface IHaveTimestamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}