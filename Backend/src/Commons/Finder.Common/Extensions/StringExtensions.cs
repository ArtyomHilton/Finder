namespace Finder.Common.Extensions;

public static class StringExtensions
{
    extension(string @string)
    {
        public bool IsNotNullOrEmpty() =>
            !string.IsNullOrEmpty(@string);

        public bool IsNotNullOrWhiteSpace() =>
            !string.IsNullOrWhiteSpace(@string);
    }
}
