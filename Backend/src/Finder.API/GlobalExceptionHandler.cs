using Finder.Common.API.Helpers;
using Finder.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Finder.API;

/// <summary>
/// Глобальный обработчик исключений
/// </summary>
/// <param name="logger"></param>
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case DomainException domainException:
                return await HandleDomainExceptionAsync(httpContext, domainException, cancellationToken);
            default:
                return await HandleUnhandledExceptionAsync(httpContext, exception, cancellationToken);
        }
    }

    private async Task<bool> HandleUnhandledExceptionAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception,"Произошло необработанное исключение [{ExceptionType}], сообщение: [{Message}]",
            exception.GetType().FullName,
            exception.Message);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(ProblemDetails.Create(StatusCodes.Status500InternalServerError, ApiConstants.Titles.InternalServer, ApiConstants.Messages.InternalServer), 
            cancellationToken);

        return true;
    }

    private async Task<bool> HandleDomainExceptionAsync(HttpContext httpContext, DomainException exception, CancellationToken cancellationToken)
    {
        logger.LogWarning("Произошло доменное исключение [{DomainExceptionType}], сообщение: [{Message}]", 
            exception.GetType().FullName, 
            exception.Message);
        
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(ProblemDetails.Create(StatusCodes.Status400BadRequest, ApiConstants.Titles.Validation, exception.Message), 
            cancellationToken);

        return true;
    }
}
