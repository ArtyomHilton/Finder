namespace Finder.Identity.Domain;

public static class DomainRules
{
    public static class User
    {
        public static class Login
        {
            public const string Regex = @"[a-zA-Z@#$&*!\-]{8,64}";
            public const int MinLength = 8;
            public const int MaxLength = 64;
        }

        public static class UserInfo
        {
            public const string NameRegex = @"[a-zA-Zа-яА-ЯёЁ\-']";
            public const int MinAge = 16;
        }
    }
}
