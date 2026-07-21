using System.Reflection;
using Finder.Common.API.Extensions;
using Finder.Common.CQRS;
using Finder.Identity.Application;
using Finder.Identity.Infrastructure;

namespace Finder.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    extension(WebApplicationBuilder webApplicationBuilder)
    {
        public WebApplicationBuilder Configure(IConfiguration configuration)
        {
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.AddApiVersioning();
            webApplicationBuilder.Services.AddCQRS(Assembly.GetExecutingAssembly());
            webApplicationBuilder.AddModules(configuration);
            return webApplicationBuilder;
        }

        private WebApplicationBuilder AddModules(IConfiguration configuration)
        {
            webApplicationBuilder.Services.AddIdentityInfrastructure(configuration);
            webApplicationBuilder.Services.AddIdentityApplication();

            return webApplicationBuilder;
        }
    }
}
