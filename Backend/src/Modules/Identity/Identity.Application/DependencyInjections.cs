using Microsoft.Extensions.DependencyInjection;

namespace Finder.Identity.Application;

public static class DependencyInjections
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddIdentityApplication()
        {
            return serviceCollection;
        }
    }
}