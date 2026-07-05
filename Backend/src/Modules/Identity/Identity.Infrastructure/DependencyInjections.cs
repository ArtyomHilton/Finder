using Finder.Identity.Application.Abstractions.Settings;
using Finder.Identity.Infrastructure.DataAccess;
using Finder.Identity.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finder.Identity.Infrastructure;

public static class DependencyInjections
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddIdentityInfrastructure(IConfiguration configuration)
        {
            serviceCollection.AddSettings(configuration);
            serviceCollection.AddDatabase();
            return serviceCollection;
        }

        private IServiceCollection AddSettings(IConfiguration configuration)
        {
            serviceCollection.Configure<DatabaseSettings>(configuration.GetRequiredSection(nameof(DatabaseSettings)));
            serviceCollection.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            return serviceCollection;
        }

        private IServiceCollection AddDatabase()
        {
            serviceCollection.AddDbContext<IdentityDbContext>((sp, builder) =>
            {
                var settings = sp.GetRequiredService<IDatabaseSettings>();

                builder.UseNpgsql(settings.ConnectionString, options =>
                {
                    options.EnableRetryOnFailure(5);
                });
            });

            return serviceCollection;
        }
    }
}
