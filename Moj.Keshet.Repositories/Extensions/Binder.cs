using System;
using Microsoft.Extensions.DependencyInjection;
using Moj.Keshet.Repositories.Implementations.Database;
using Moj.Keshet.Repositories.Implementations.Demography;
using Moj.Keshet.Repositories.Interfaces;
using Moj.Keshet.Repositories.Interfaces.Demography;
using Moj.Keshet.Repositories.Implementations.Database.Repositories;
using Moj.Keshet.Services.Interfaces;
using AutoMapper;
using Moj.Keshet.Repositories.Mapping;
using Moj.Keshet.Repositiories.Proxy.Implementation;
using Moj.Keshet.Services.Interfaces.ListItems;

namespace Moj.Keshet.Repositories.Extensions
{
    public static class Binder
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services)
        {
            #region Base Repositories
            services.AddScoped<Repository>();
            services.AddScoped(provider => new Lazy<Repository>(provider.GetService<Repository>));

            services.AddScoped<IBaseRepository, Repository>();
            services.AddScoped(provider => new Lazy<IBaseRepository>(provider.GetService<Repository>));

            #endregion
            services.AddScoped<ServiceExampleProxy>();
            services.AddScoped<IServiceExampleProxy>(x => x.GetRequiredService<ServiceExampleProxy>());


            services.AddSingleton<DemographyRepository>();
            services.AddSingleton<IDemographyRepository>(x => x.GetRequiredService<DemographyRepository>());
            services.AddSingleton<IDemographyLoader>(x => x.GetRequiredService<DemographyRepository>());
            services.AddSingleton(provider => new Lazy<IDemographyRepository>(provider.GetRequiredService<DemographyRepository>));

            services.AddScoped<KeshetEntities>();

            #region Contacts Repositories

            services.AddScoped<IContactsRepository, Repository>();
            services.AddScoped(provider => new Lazy<IContactsRepository>(provider.GetService<Repository>));
            services.AddScoped<IContactsListItemsRepository, Repository>();
            services.AddScoped(provider => new Lazy<IContactsListItemsRepository>(provider.GetService<Repository>));
          
            #endregion

            #region Processes Repositories

            services.AddScoped<IProcessesRepository, Repository>();
            services.AddScoped(provider => new Lazy<IProcessesRepository>(provider.GetService<Repository>));

            services.AddScoped<IProcessesListItemsRepository, Repository>();
            services.AddScoped(provider => new Lazy<IProcessesListItemsRepository>(provider.GetService<Repository>));
            #endregion

            #region ListItems Repositories

            services.AddScoped<ICommonListItemsRepository, Repository>();
            services.AddScoped(provider => new Lazy<ICommonListItemsRepository>(provider.GetService<Repository>));
            #endregion

            return services;
        }
    }
}
