namespace Finder.Common.CQRS.Abstractions.Handlers;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<TReturn, TCommand> where TCommand : ICommand
{
    Task<TReturn> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
