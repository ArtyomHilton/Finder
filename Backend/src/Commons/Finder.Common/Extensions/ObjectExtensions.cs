namespace Finder.Common.Extensions;

public static class ObjectExtensions
{
    extension(object? @object)
    {
        public bool IsNull() =>
            @object is null;

        public bool IsNotNull() =>
            @object is not null;
    }
}