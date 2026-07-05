using Finder.Identity.Application.Abstractions.Settings;
using Microsoft.Extensions.Configuration;

namespace Finder.Identity.Infrastructure.Settings;

class DatabaseSettings : IDatabaseSettings
{
    [ConfigurationKeyName("DATABASE_CONNECTION_STRING")]
    public string ConnectionString { get; init; } = null!;
}
