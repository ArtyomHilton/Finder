using Finder.API;
using Finder.Common.API.Helpers;
using Finder.Common.Results;
using Finder.Common.Results.Errors;
using Microsoft.AspNetCore.Http;

namespace Finder.Common.API.Extensions;

public static class ResultExtensions
{
    extension(Result result)
    {
        /// <summary>
        /// Конвертирует <see cref="Result"/> в <see cref="IResult"/>
        /// </summary>
        /// <returns><see cref="IResult"/></returns>
        public IResult ToResponse()
        {
            if (result.IsSuccess) return TypedResults.NoContent();

            return MapErrorToResult(result.Error);
        }
    }

    extension<TValue>(Result<TValue> result)
    {
        /// <summary>
        /// Конвертирует <see cref="Result{TValue}"/> в <see cref="IResult"/>
        /// </summary>
        /// <returns><see cref="IResult"/></returns>
        public IResult ToResponse()
        {
            if (result.IsSuccess) return TypedResults.Ok(result.Value);

            return MapErrorToResult(result.Error);
        }
    }

    /// <summary>
    /// Конвертирует <see cref="Error"/> в <see cref="IResult"/>
    /// </summary>
    /// <param name="error"><see cref="Error"/></param>
    /// <returns><see cref="IResult"/></returns>
    private static IResult MapErrorToResult(Error error) =>
        error.Type switch
        {
            ErrorType.NotFound => TypedResults.NotFound(ProblemDetails.Create(StatusCodes.Status404NotFound, ApiConstants.Titles.NotFound, error.Description)),
            ErrorType.Unauthorized => TypedResults.Json(data: ProblemDetails.Create(StatusCodes.Status401Unauthorized, ApiConstants.Titles.Unauthorized, error.Description),
                statusCode: StatusCodes.Status401Unauthorized),
            ErrorType.Validation => TypedResults.BadRequest(ProblemDetails.Create(StatusCodes.Status400BadRequest, ApiConstants.Titles.Validation, error.Description)),
            ErrorType.BadRequest => TypedResults.BadRequest(ProblemDetails.Create(StatusCodes.Status400BadRequest, ApiConstants.Titles.BadRequest, error.Description)),
            _ => TypedResults.InternalServerError(ProblemDetails.Create(StatusCodes.Status500InternalServerError, ApiConstants.Titles.InternalServer, error.Description)),
        };
}
