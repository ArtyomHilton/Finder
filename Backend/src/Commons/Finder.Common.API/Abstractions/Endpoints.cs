using Microsoft.AspNetCore.Routing;

namespace Finder.Common.API.Abstractions;

/// <summary>
/// Базовый класс эндпоинтов
/// </summary>
public abstract class Endpoints
{
    /// <summary>
    /// Путь группы
    /// </summary>
    protected abstract string Group { get; }

    /// <summary>
    /// Регистрирует эндпоинты
    /// </summary>
    /// <param name="endpointRouteBuilder"><see cref="IEndpointRouteBuilder"/></param>
    public abstract void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder);
}
