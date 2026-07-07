using Finder.Common.Results.Errors;

namespace Finder.Common.Results;

/// <summary>
/// Результат
/// </summary>
public class Result
{
    private readonly Error? _error;
    protected readonly bool _isSuccess;

    public Error Error => IsFailure
        ? _error!
        : throw new InvalidOperationException("Нельзя получить ошибку при успешном результате");

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;

    protected Result(Error? error, bool isSuccess)
    {
        _error = error;
        _isSuccess = isSuccess;
    }

    public static Result Success() =>
        new Result(null, true);

    public static Result Failure(Error error) =>
        new Result(error, false);
}

/// <summary>
/// Результат со значением
/// </summary>
/// <typeparam name="TValue">Любой тип</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public TValue Value => _isSuccess
        ? _value!
        : throw new InvalidOperationException("Нельзя получить значение при неуспешном результате");

    private Result(TValue? value, Error? error, bool isSuccess)
        : base(error, isSuccess)
    {
        _value = value;
    }

    public static Result Success(TValue value) =>
        new Result<TValue>(value, null, true);

    public new static Result Failure(Error error) =>
        new Result<TValue>(default(TValue), error, false);
}