namespace Finder.Common.API.Helpers;

public static class ProblemDetails
{
    public static Microsoft.AspNetCore.Mvc.ProblemDetails Create(int statusCode, string title, string message) =>
        new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = message
        };
}
