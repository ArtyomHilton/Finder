using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Finder.Common.Redis;

public static class RedisDependencyInjections
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddCacheClient(IConfiguration configuration)
        {
            serviceCollection.AddStackExchangeConfiguration(configuration);

            return serviceCollection;
        }

        private IServiceCollection AddStackExchangeConfiguration(IConfiguration configuration)
        {
            serviceCollection.Configure<RedisConfiguration>(configuration.GetSection(nameof(RedisConfiguration)));

            serviceCollection.AddSingleton<IDatabase>(sp =>
            {
                var redisConfiguration = sp.GetRequiredService<RedisConfiguration>();

                var multiplexer = ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString);

                return multiplexer.GetDatabase();
            });

            serviceCollection.AddSingleton<ICacheClient, RedisCacheClient>();

            return serviceCollection;
        }
    }
}
