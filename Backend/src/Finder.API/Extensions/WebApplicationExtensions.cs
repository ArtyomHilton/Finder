using Finder.Common.EF.Extensions;
using Finder.Identity.Infrastructure.DataAccess;
using Scalar.AspNetCore;

namespace Finder.API.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public async Task<WebApplication> ConfigureAsync()
        {
            webApplication.AddScalar();
            await webApplication.ApplyMigrationsAsync();
            return webApplication;
        }

        private WebApplication AddScalar()
        {
            webApplication.MapOpenApi();
            webApplication.MapScalarApiReference(options =>
            {
                options.WithTitle("Finder API");
            });

            return webApplication;
        }

        private async Task<WebApplication> ApplyMigrationsAsync()
        {
            await webApplication.ApplyMigrationsAsync<IdentityDbContext>();

            return webApplication;
        }
    }
}
