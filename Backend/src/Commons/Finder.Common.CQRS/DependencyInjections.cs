using System.Reflection;
using Finder.Common.CQRS.Abstractions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Finder.Common.CQRS;

public static class DependencyInjections
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddCQRS(Assembly assembly)
        {
            var types = new List<Type>();

            foreach (var ass in assembly.GetReferencedAssemblies().ToList())
            {
                types.AddRange(Assembly.Load(ass).GetTypes());
            }

            serviceCollection.RegistrationCommandHandlers(types);
            serviceCollection.RegistrationQueryHandlers(types);

            return serviceCollection;
        }

        private IServiceCollection RegistrationCommandHandlers(IEnumerable<Type> types)
        {
            serviceCollection.RegistrationInDI(GetTypes(types, typeof(ICommandHandler<>)), $"{nameof(ICommandHandler<>)}`1");
            serviceCollection.RegistrationInDI(GetTypes(types, typeof(ICommandHandler<,>)), $"{nameof(ICommandHandler<>)}`2");

            return serviceCollection;
        }

        private IServiceCollection RegistrationQueryHandlers(IEnumerable<Type> types)
        {
            serviceCollection.RegistrationInDI(GetTypes(types, typeof(IQueryHandler<,>)), $"{nameof(IQueryHandler<,>)}`2");

            return serviceCollection;
        }

        private IServiceCollection RegistrationInDI(IEnumerable<Type> types, string abstractionName)
        {
            foreach (var type in types)
            {
                var abstraction = type.GetInterface(abstractionName, true);

                serviceCollection.AddScoped(abstraction!, type);
            }

            return serviceCollection;
        }
    }

    private static List<Type> GetTypes(IEnumerable<Type> types, Type implimentation) =>
            types.Where(x => !x.IsInterface && !x.IsAbstract)
                .Where(type => type.GetInterfaces()
                    .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == implimentation)).ToList();
}
