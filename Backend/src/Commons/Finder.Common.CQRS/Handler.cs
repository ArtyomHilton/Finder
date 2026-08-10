using Finder.Common.CQRS.Abstractions;
using Finder.Common.CQRS.Abstractions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Finder.Common.CQRS;

sealed class Handler(IServiceProvider serviceProvider) : IHandler
{
    public Task HandleAsync(ICommand command, CancellationToken cancellationToken)
    {
        var service = serviceProvider.GetRequiredService(typeof(ICommandHandler<>).MakeGenericType(command.GetType()));

        return (Task)service.GetType().GetMethod(nameof(ICommandHandler<>.HandleAsync))!.Invoke(service, [command, cancellationToken])!;
    }

    public Task<TReturn> HandleAsync<TReturn>(ICommand command, CancellationToken cancellationToken)
    {
        var service = serviceProvider.GetRequiredService(typeof(ICommandHandler<,>).MakeGenericType(typeof(TReturn), command.GetType()));

        return (Task<TReturn>)service.GetType().GetMethod(nameof(ICommandHandler<,>.HandleAsync))!.Invoke(service, [command, cancellationToken])!;
    }

    public Task<TQueryReturn> HandleAsync<TQueryReturn>(IQuery query, CancellationToken cancellationToken)
    {
        var service = serviceProvider.GetRequiredService(typeof(IQueryHandler<,>).MakeGenericType(typeof(TQueryReturn), query.GetType()));

        return (Task<TQueryReturn>)service.GetType().GetMethod(nameof(IQueryHandler<,>))!.Invoke(service, [query, cancellationToken])!;
    }
}
