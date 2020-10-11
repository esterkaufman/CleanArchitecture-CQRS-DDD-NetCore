using Moj.Core.Rest.Common.Extensions;

namespace Moj.Keshet.Domain.Extensions
{
    public static class CloningExtensions
    {
        public static T DeepClone<T>(this T instance) where T : class
        {
            return instance.JsonSerialize().JsonDeserialize<T>();
        }
    }
}
