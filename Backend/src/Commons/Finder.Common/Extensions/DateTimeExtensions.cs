namespace Finder.Common.Extensions;

public static class DateTimeExtensions
{
    extension(DateTime dateTime)
    {
        public DateOnly ToDateOnly() =>
            DateOnly.FromDateTime(dateTime);

        public TimeOnly ToTimeOnly() =>
            TimeOnly.FromDateTime(dateTime);
    }
}
