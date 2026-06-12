namespace Finder.Common.EF.Abstractions;

public interface IHaveTimeStamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}