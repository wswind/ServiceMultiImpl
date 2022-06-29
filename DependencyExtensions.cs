//generic factory from https://stackoverflow.com/a/59338701/7726468
//origin author is 'T Brown'
//licence: CC BY-SA 4.0

using ServiceMultiImpl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static FactoryBuilder<TService, TKey> AddFactory<TService, TKey>(this IServiceCollection services)
            where TService : class
        {
            services.AddTransient<IFactory<TService, TKey>, Factory<TService, TKey>>();
            return new FactoryBuilder<TService, TKey>(services);
        }
    }
}