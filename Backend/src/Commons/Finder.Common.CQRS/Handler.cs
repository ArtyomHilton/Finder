using Finder.Common.CQRS.Abstractions;
using Finder.Common.CQRS.Abstractions.Handlers;

namespace Finder.Common.CQRS;

sealed class Handler : IHandler
{
    public Task HandleAsync(ICommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TReturn> HandleAsync<TReturn>(ICommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TReturn> HandleAsync<TReturn>(IQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
