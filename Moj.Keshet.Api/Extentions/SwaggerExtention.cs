using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Moj.Keshet.Services.DTOs.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Moj.Keshet.Api.Extentions
{
    public static class MojSwaggerExtension
    {

        public static IServiceCollection UseMojSwagger(this IServiceCollection services, string ApplicationName, string ApplicationDescription, ApiVersions apiVersions, string projectName)
        {
            services.AddApiVersioning(config =>
            {
                var apiVersion = "1.0";
                if (apiVersions.Versions.First(d => d.Default).Name != "1")
                    apiVersion = apiVersions.Versions.First(d => d.Default).Name;

                var defaultVersion = new System.Version(apiVersion);//);
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(defaultVersion.Major, defaultVersion.Minor);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.MojConfigSwagger(ApplicationName, ApplicationDescription, apiVersions, projectName);
                // c.SwaggerDoc("v1", new OpenApiInfo { Title = $"API {ApplicationName} ", Version = "v1" });
                c.AddFluentValidationRules();

            });

            return services;
        }

        public static IApplicationBuilder UseMojSwagger(this IApplicationBuilder app, string ApplicationName, ApiVersions apiVersions)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    var api = "api/";
#if DEBUG
                    api = "";
#endif
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/{api}" } };
                });
            });


            app.UseSwaggerUI(c =>
            {
                foreach (var version in apiVersions.Versions)
                {
                    c.SwaggerEndpoint($"/swagger/v{ version.Name }/swagger.json", $"{ApplicationName} API V{ version.Name }");
                }
            });

            return app;
        }



        #region Private
        private static SwaggerGenOptions MojConfigSwagger(this SwaggerGenOptions swaggerGenOptions, string appName, string appDescription, ApiVersions versions, string projectName)
        {
            foreach (var version in versions.Versions)
            {
                swaggerGenOptions.SwaggerDoc($"v{ version.Name }", new OpenApiInfo
                {
                    Title = $"API {appName} ",
                    Description = $"{appDescription}",
                    Version = $"v{ version.Name }"
                });
            }

            swaggerGenOptions.AddFluentValidationRules();

            ///var path = Path.Combine(AppContext.BaseDirectory, $"{projectName}.xml");
            //swaggerGenOptions.IncludeXmlComments(path, true);

            if (versions.GroupByVersion)
            {
                swaggerGenOptions.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(version => $"v{version}" == docName);
                });
            }

            return swaggerGenOptions;
        }
        #endregion
    }
}
