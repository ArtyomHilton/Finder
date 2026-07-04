using System.Text.RegularExpressions;
using Finder.Common.Extensions;
using Finder.Identity.Domain.Exceptions;

namespace Finder.Identity.Domain.Entities.User.ValueObjects;

public class UserInfo
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? Patronymic { get; private set; }
    public DateOnly BirthdayDate { get; private set; }

    public UserInfo WithFirstName(string firstName) =>
        Create(firstName, LastName, Patronymic, BirthdayDate);

    public UserInfo WithLastName(string lastName) =>
        Create(FirstName, lastName, Patronymic, BirthdayDate);

    public UserInfo WithPatronymic(string patronymic) =>
        Create(FirstName, LastName, patronymic, BirthdayDate);

    public UserInfo WithBirthdayDate(DateOnly birthdayDate) =>
        Create(FirstName, LastName, Patronymic, birthdayDate);

    private UserInfo(string firstName, string lastName, string? patronymic, DateOnly birthdayDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        BirthdayDate = birthdayDate;
    }

    public static UserInfo Create(string firstName, string lastName, string? patronymic, DateOnly birthdayDate)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);
        ValidatePatronymic(patronymic);
        ValidateBirthdayDate(birthdayDate);

        return new UserInfo(firstName, lastName, patronymic, birthdayDate);
    }

    private static void ValidateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException(DomainMessages.User.UserInfo.FirstNameEmpty, nameof(FirstName));

        if(!Regex.IsMatch(firstName, DomainRules.User.UserInfo.NameRegex))
            throw new DomainException(DomainMessages.User.UserInfo.FirstNameNotCorrectFormat, nameof(FirstName));
    }

    private static void ValidateLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException(DomainMessages.User.UserInfo.LastNameEmpty, nameof(FirstName));

        if (!Regex.IsMatch(lastName, DomainRules.User.UserInfo.NameRegex))
            throw new DomainException(DomainMessages.User.UserInfo.LastNameNotCorrectFormat, nameof(FirstName));
    }

    private static void ValidatePatronymic(string? patronymic)
    {
        if (string.IsNullOrWhiteSpace(patronymic)) return;

        if (!Regex.IsMatch(patronymic, DomainRules.User.UserInfo.NameRegex))
            throw new DomainException(DomainMessages.User.UserInfo.PatronymicNotCorrectFormat, nameof(FirstName));
    }

    private static void ValidateBirthdayDate(DateOnly birthdayDate)
    {
        var nowDateTime = DateTime.UtcNow;

        if (nowDateTime.ToDateOnly() < birthdayDate)
            throw new DomainException(DomainMessages.User.UserInfo.BirthdayDateCannotBeGreaterCurrentDate, nameof(BirthdayDate));

        if (new DateTime(birthdayDate, new TimeOnly()) > nowDateTime.AddYears(-DomainRules.User.UserInfo.MinAge))
            throw new DomainException(DomainMessages.User.UserInfo.NotCorrectAge, nameof(BirthdayDate));
    }
}
