namespace Finder.Common.Redis;

public interface ICacheClient
{
    Task SetAsync<T>(string key, T value, TimeSpan? ttl);
    Task<T?> GetAsync<T>(string key);
}
