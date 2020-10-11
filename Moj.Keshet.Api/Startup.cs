using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moj.Core.Rest.Services;
using Moj.Keshet.Repositories.Extensions;
using Moj.Keshet.Services.Extensions;
using Moj.Keshet.Domain;
using Moj.Keshet.Services.DTOs.Configuration;
using Moj.Keshet.Services.MediatR.Queries.Contacts;
using Moj.Keshet.Api.Extentions;
using Moj.Keshet.Ioc;

namespace Moj.Keshet.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public const string ApplicationName = "Keshet";
        public const string ApplicationDescription = "Keshet - Appeal Organizations service API";

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseMojCore(Configuration.GetConnectionString("DefaultConnection"));
            //keep data in AppSettings in file appsettings.json and stored it in the container
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            // Get Configuration from DataBase
            var sp = services.BuildServiceProvider();
            var coreConfiguration = sp.GetService<Moj.Core.Rest.Interfaces.IConfigurations>();
            var appSettingsCore = coreConfiguration.Get<AppSettings>();
            var apiVersions = coreConfiguration.Get<ApiVersions>();
                        
            services.AddCors(
            options => options.AddPolicy(
                "AllowOrigin",
                builder => builder
                    .WithOrigins("http://localhost:4202")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            ));

            services.AddMvc(
                //o=> o.Filters.Add(new HttpResponseExceptionFilter())
                ).AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    opt.RegisterValidatorsFromAssemblyContaining<GetContactHandler>();
                });

            var projectName = GetType().Assembly.GetName().Name;
            services.UseMojSwagger(ApplicationName, ApplicationDescription, apiVersions, projectName);

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddHostedService<Repositories.Implementations.Demography.DemographyTimer>();

            services.UseInjection();

        }

        public static void ConfigureDesignTimeServices(IServiceCollection services)
        {
            //services.AddSingleton<EntityTypeWriter, CustomEntitiyTypeWriter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region api swagger
            var coreConfiguration = app.ApplicationServices.GetService<Moj.Core.Rest.Interfaces.IConfigurations>();
            var apiVersions = coreConfiguration.Get<ApiVersions>();
            app.UseMojSwagger(ApplicationName, apiVersions);
            #endregion          

            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMojCore(env);




        }


    }
}
