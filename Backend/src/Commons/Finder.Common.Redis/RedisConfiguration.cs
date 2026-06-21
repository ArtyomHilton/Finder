using Microsoft.Extensions.Configuration;

namespace Finder.Common.Redis;

public class RedisConfiguration
{
    [ConfigurationKeyName("REDIS_CONNECTION_STRING")]
    public string ConnectionString { get; set; } = null!;
}
