namespace Finder.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder webApplicationBuilder)
    {
        public void Configure()
        {
            webApplicationBuilder.Services.AddOpenApi();
        }
    }
}
