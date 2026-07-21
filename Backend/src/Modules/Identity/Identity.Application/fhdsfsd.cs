using Finder.Common.CQRS.Abstractions;
using Finder.Common.CQRS.Abstractions.Handlers;

namespace Finder.Identity.Application;

sealed class Handler : ICommandHandler<Geeeeerrer>
{
    public Task HandleAsync(Geeeeerrer command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public sealed record Geeeeerrer : ICommand
{

}