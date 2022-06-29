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
