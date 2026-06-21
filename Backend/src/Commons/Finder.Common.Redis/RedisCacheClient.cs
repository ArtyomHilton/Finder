using Finder.Common.Extensions;
using StackExchange.Redis;

namespace Finder.Common.Redis;

class RedisCacheClient(IDatabase redis) : ICacheClient
{
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await redis.StringGetAsync(key);

        return value.ToString().FromJson<T>();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? ttl) =>
        await redis.StringSetAsync(key, redis.ToJson(), ttl, false);
}
