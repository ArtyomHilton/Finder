using System.Text.Json;

namespace Finder.Common.Extensions;

public static class JsonExtensions
{
    extension(object @object)
    {
        public string ToJson() =>
            JsonSerializer.Serialize(@object);
    }

    extension(string jsonString)
    {
        public T? FromJson<T>() =>
            JsonSerializer.Deserialize<T>(jsonString);
    }
}