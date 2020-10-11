using Microsoft.Extensions.DependencyInjection;

namespace Moj.Keshet.Shared
{
    public static class Binder
    {
        public static IServiceCollection UseShared(this IServiceCollection services)
        {
            
            return services;
        }
    }
}