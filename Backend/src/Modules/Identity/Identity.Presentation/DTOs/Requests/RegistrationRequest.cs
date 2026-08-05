using Finder.Identity.Application.UseCases.Auth.Registration;

namespace Finder.Identity.Presentation.DTOs.Requests;

/// <summary>
/// Модель запроса для регистрации пользователя
/// </summary>
/// <param name="Login">Логин</param>
/// <param name="Password">Пароль</param>
/// <param name="FirstName">Имя</param>
/// <param name="LastName">Фамилия</param>
/// <param name="Patronymic">Отчество</param>
/// <param name="BirthdayDate">Дата рождения</param>
public sealed record RegistrationRequest(string Login, 
    string Password, 
    string FirstName, 
    string LastName, 
    string? Patronymic, 
    DateOnly BirthdayDate)
{
    public static explicit operator RegistrationCommand(RegistrationRequest request) =>
        new RegistrationCommand(request.Login, request.Password, request.FirstName, request.LastName, request.Password, request.BirthdayDate);
}
