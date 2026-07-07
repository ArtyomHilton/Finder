using Asp.Versioning;
using Finder.Common.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Finder.Common.API.Extensions;

public static class ApiExtensions
{
    extension(WebApplicationBuilder webApplicationBuilder)
    {
        public WebApplicationBuilder AddApiVersioning()
        {
            webApplicationBuilder.Services.AddOpenApi();
            webApplicationBuilder.Services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.DefaultApiVersion = new ApiVersion(1);
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return webApplicationBuilder;
        }
    }
}
