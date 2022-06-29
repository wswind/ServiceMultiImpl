//Origin Author is 'T Brown' from https://stackoverflow.com/a/59338701/7726468
//Licence: CC BY-SA 4.0
//Updated by Vincent Wang https://github.com/wswind/ServiceMultiImpl

using ServiceMultiImpl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static MultiImplServiceFactoryBuilder<TService, TKey> AddMultiImplServiceFactory<TService, TKey>(this IServiceCollection services)
            where TService : class
        {
            MultiImplTypeMapper<TService, TKey> factoryTypes = new();
            services.AddSingleton(factoryTypes);
            services.AddTransient<IMultiImplServiceFactory<TService, TKey>, MultiImplServiceFactory<TService, TKey>>();
            return new MultiImplServiceFactoryBuilder<TService, TKey>(services, factoryTypes);
        }
    }
}