namespace Finder.Common.Results.Errors;

/// <summary>
/// Ошибка
/// </summary>
public class Error
{
    public ErrorType Type { get; init; }
    public string Description { get; init; }

    private Error(ErrorType type, string description)
    {
        Type = type;
        Description = description;
    }

    public static Error NotFound(string description) =>
        new Error(ErrorType.NotFound, description);

    public static Error Validation(string description) =>
        new Error(ErrorType.Validation, description);

    public static Error Unauthorize(string description) =>
        new Error(ErrorType.Unauthorize, description);

    public static Error BadRequest(string description) =>
        new Error(ErrorType.BadRequest, description);
}
