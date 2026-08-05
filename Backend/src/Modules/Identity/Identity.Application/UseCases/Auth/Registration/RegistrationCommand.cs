namespace Finder.Identity.Application.UseCases.Auth.Registration;

/// <summary>
/// Команда регистрации пользователя
/// </summary>
/// <param name="Login">Логин</param>
/// <param name="Password">Пароль</param>
/// <param name="FirstName">Имя</param>
/// <param name="LastName">Фамилия</param>
/// <param name="Patronymic">Отчество</param>
/// <param name="BirthdayDate">Дата рождения</param>
public sealed record RegistrationCommand(string Login,
    string Password,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly BirthdayDate);