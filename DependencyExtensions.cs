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