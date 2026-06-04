using Scalar.AspNetCore;

namespace Finder.API.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public void Configure()
        {
            webApplication.AddScalar();
        }

        private void AddScalar()
        {
            webApplication.MapOpenApi();
            webApplication.MapScalarApiReference(options =>
            {
                options.WithTitle("Finder API");
            });
        }
    }
}
