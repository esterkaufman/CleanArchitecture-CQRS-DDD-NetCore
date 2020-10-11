using Microsoft.Extensions.DependencyInjection;

namespace Moj.Keshet.Domain.Extensions
{
    public static class Binder
    {
        public static IServiceCollection UseDomain(this IServiceCollection services)
        {
            //services.AddScoped<CodeTables>();
            //services.AddScoped<ExtendedCodeTables>();
           // services.AddScoped<GlobalParameters>();
            return services;
        }
    }
}
