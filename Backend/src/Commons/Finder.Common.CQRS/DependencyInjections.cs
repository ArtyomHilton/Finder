using System.Reflection;
using Finder.Common.CQRS.Abstractions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Finder.Common.CQRS;

public static class DependencyInjections
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddCQRS()
        {
            serviceCollection.AddScoped<IHandler, Handler>();

            return serviceCollection;
        }
    }
}