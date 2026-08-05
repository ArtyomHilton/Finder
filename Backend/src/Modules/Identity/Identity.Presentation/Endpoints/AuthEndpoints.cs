using Asp.Versioning;
using Finder.Common.API.Extensions;
using Finder.Identity.Application.UseCases.Auth.Registration;
using Finder.Identity.Presentation.DTOs.Requests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Finder.Identity.Presentation.Endpoints;

/// <summary>
/// Эндпоинты для аутентификации
/// </summary>
public sealed class AuthEndpoints : Common.API.Abstractions.Endpoints
{
    /// <inheritdoc />
    protected override string Group => "api/v{version:apiVersion}/auth";

    /// <inheritdoc />
    public override void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var apiVersionSet = endpointRouteBuilder.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var group = endpointRouteBuilder.MapGroup(Group)
            .WithApiVersionSet(apiVersionSet);


        group.MapPost("registration", RegistrationAsync);
    }

    /// <summary>
    /// Регистрация
    /// </summary>
    /// <param name="request"><see cref="RegistrationRequest"/></param>
    /// <param name="useCase"><see cref="IRegistrationUseCase"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="IResult"/></returns>
    private async Task<IResult> RegistrationAsync([FromBody] RegistrationRequest request,
        [FromServices] IRegistrationUseCase useCase,
        CancellationToken cancellationToken)
    {
        return (await useCase.ExecuteAsync((RegistrationCommand)request, cancellationToken)).ToResponse();
    }
}
