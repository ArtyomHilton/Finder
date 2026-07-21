namespace Finder.Common.CQRS.Abstractions.Handlers;

public interface IHandler
{
    Task HandleAsync(ICommand command, CancellationToken cancellationToken);
    Task<TReturn> HandleAsync<TReturn>(ICommand command, CancellationToken cancellationToken);
    Task<TReturn> HandleAsync<TReturn>(IQuery query, CancellationToken cancellationToken);
}