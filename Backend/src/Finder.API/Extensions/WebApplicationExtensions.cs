using Scalar.AspNetCore;

namespace Finder.API.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication webApplication)
    {
        public WebApplication Configure()
        {
            webApplication.AddScalar();
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
    }
}
