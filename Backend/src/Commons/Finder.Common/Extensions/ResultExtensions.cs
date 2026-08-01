using Finder.Common.Results;
using Finder.Common.Results.Errors;

namespace Finder.Common.Extensions;

public static class ResultExtensions
{
    extension(Result result)
    {
        public static Result Success() =>
        new Result(null, true);

        public static Result Failure(Error error) =>
            new Result(error, false);

        public static Result Success<TValue>(TValue value) =>
        new Result<TValue>(value, null, true);

        public static Result Failure<TValue>(Error error) =>
            new Result<TValue>(default(TValue), error, false);
    }
}
