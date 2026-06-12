namespace Finder.Common.EF.Abstractions;

public interface IEntity { }

public interface IEntity<T>
{
    T Id { get; set; }
}