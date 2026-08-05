using Finder.Common.Results;

namespace Finder.Identity.Application.UseCases.Auth.Registration;

/// <summary>
/// Юз кейс регистрации
/// </summary>
public interface IRegistrationUseCase
{
    /// <summary>
    /// Выполняет команду регистрации
    /// </summary>
    /// <param name="command"><see cref="RegistrationCommand"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Result"/></returns>
    Task<Result> ExecuteAsync(RegistrationCommand command, CancellationToken cancellationToken);
}
