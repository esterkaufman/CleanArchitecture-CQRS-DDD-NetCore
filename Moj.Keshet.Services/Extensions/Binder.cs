using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.MetiatR_LogAndValidate;
using Moj.Keshet.Services.Mapping;
using AutoMapper;
using Moj.Keshet.Services.Implementations;
using System;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Services.Implementations.ListItems;

namespace Moj.Keshet.Services.Extensions
{
    public static class Binder
    {
        public static IServiceCollection UseServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.UseMapper();
            return services
                    .AddScoped<IProvider, Provider>()
                    .AddScoped<IContactsProvider, Provider>()
                    .AddScoped<IProcessesProvider, Provider>()
                    .AddScoped<IContactsListItemsProvider, ContactsListItemsProvider>()
                       .AddScoped<IProcessesListItemsProvider, ProcessesListItemsProvider>()


                    .AddMediatR(Assembly.GetExecutingAssembly())
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(TracingBehavior<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>))

                ;


            ;
        }
    }
}
