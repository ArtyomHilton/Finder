namespace Finder.Common.EF.Abstractions;

public interface IEntity { }

public interface IEntity<T> : IEntity
{
    T Id { get;}
}