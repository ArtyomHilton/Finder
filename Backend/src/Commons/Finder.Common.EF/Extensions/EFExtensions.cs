using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Finder.Common.EF.Extensions;

public static class EFExtensions
{
    extension(IApplicationBuilder applicationBuilder)
    {
        public async Task ApplyMigrationsAsync<T>() where T : DbContext
        {
            var context = applicationBuilder.ApplicationServices.GetRequiredService<T>();

            await context.Database.MigrateAsync();
        }
    }
}