using Finder.Common.API;

namespace Finder.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder webApplicationBuilder)
    {
        public WebApplicationBuilder Configure()
        {
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.AddApiVersioning();

            return webApplicationBuilder;
        }
    }
}
