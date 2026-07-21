namespace Finder.Common.CQRS.Abstractions.Handlers;

public interface IQueryHandler<TQueryReturn, TQuery> where TQuery : IQuery
{
    Task<TQueryReturn> HandleAsync(TQuery query, CancellationToken cancellationToken);
}
