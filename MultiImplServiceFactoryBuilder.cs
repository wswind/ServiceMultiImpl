//Origin Author is 'T Brown' from https://stackoverflow.com/a/59338701/7726468
//Licence: CC BY-SA 4.0
//Updated by Vincent Wang https://github.com/wswind/ServiceMultiImpl

namespace ServiceMultiImpl
{
    public class MultiImplServiceFactoryBuilder<TService, TKey> where TService : class
    {
        private readonly IServiceCollection _services;
        private readonly MultiImplTypeMapper<TService, TKey> _factoryTypes;

        public MultiImplServiceFactoryBuilder(IServiceCollection services, MultiImplTypeMapper<TService, TKey> factoryTypes)
        {
            _services = services;
            _factoryTypes = factoryTypes;
        }

        public MultiImplServiceFactoryBuilder<TService, TKey> Add<TImplementation>(TKey key)
            where TImplementation : class, TService
        {
            _factoryTypes.ServiceList.Add(key, typeof(TImplementation));
            _services.AddTransient<TImplementation>();
            return this;
        }
    }
}
