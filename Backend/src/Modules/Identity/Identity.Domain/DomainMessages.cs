namespace Finder.Identity.Domain;

static class DomainMessages
{
    internal static class User
    {
        internal static class Login
        {
            internal const string LoginLengthNotCorrect = "Неверная длина логина";
            internal const string LoginNotCorrectFormat = "Логин содержит запрещенный символы";
        }

        internal static class Password
        {
            internal const string PasswordCannotBeEmpty = "Пароль не может быть пустым";
        }

        internal static class UserInfo
        {
            internal const string FirstNameEmpty = "Имя не может быть пустым";
            internal const string FirstNameNotCorrectFormat = "Имя содержит запрещенные символы";

            internal const string LastNameEmpty = "Фамилия не может быть пустым";
            internal const string LastNameNotCorrectFormat = "Фамилия содержит запрещенные символы";

            internal const string PatronymicNotCorrectFormat = "Отчество содержит запрещенные символы";
            
            internal const string BirthdayDateCannotBeGreaterCurrentDate = "Дата рождения не может быть больше текущей даты";
            internal const string NotCorrectAge = "Регистрация доступна только с 16 лет";
        }
    }
}
