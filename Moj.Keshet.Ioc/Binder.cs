using Microsoft.Extensions.DependencyInjection;
using Moj.Keshet.Domain.Extensions;
using Moj.Keshet.Repositories.Extensions;
using Moj.Keshet.Services.Extensions;
using Moj.Keshet.Shared;
using System;

namespace Moj.Keshet.Ioc
{
    public static class Binder
    {
        public static IServiceCollection UseInjection(this IServiceCollection services)
        {
            services.UseShared();
            services.UseDomain();
            services.UseServices();
            services.UseRepositories();


            return services;
        }
    }
}
