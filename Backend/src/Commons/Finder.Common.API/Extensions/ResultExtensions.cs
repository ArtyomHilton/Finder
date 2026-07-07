using Finder.Common.Results;
using Finder.Common.Results.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            ErrorType.NotFound => TypedResults.NotFound(CreateProblemDetails(StatusCodes.Status404NotFound, "Not Found Error", error.Description)),
            ErrorType.Unauthorize => TypedResults.Json(data: CreateProblemDetails(StatusCodes.Status404NotFound, "Not Found Error", error.Description),
                statusCode: StatusCodes.Status401Unauthorized),
            ErrorType.Validation => TypedResults.BadRequest(CreateProblemDetails(StatusCodes.Status400BadRequest, "Validation Error", error.Description)),
            ErrorType.BadRequest => TypedResults.BadRequest(CreateProblemDetails(StatusCodes.Status400BadRequest, "Bad Request Error", error.Description)),
            _ => TypedResults.InternalServerError(CreateProblemDetails(StatusCodes.Status404NotFound, "Internal Server Error", error.Description)),
        };

    /// <summary>
    /// Создает объект <see cref="ProblemDetails"/>
    /// </summary>
    /// <param name="statusCode">Статус код</param>
    /// <param name="title">Заголовок</param>
    /// <param name="detail">Сообщение</param>
    /// <returns><see cref="ProblemDetails"/></returns>
    private static ProblemDetails CreateProblemDetails(int statusCode, string title, string detail) =>
        new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
        };
}
