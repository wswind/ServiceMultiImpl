//Origin Author is 'T Brown' from https://stackoverflow.com/a/59338701/7726468
//Licence: CC BY-SA 4.0
//Updated by Vincent Wang https://github.com/wswind/ServiceMultiImpl

namespace ServiceMultiImpl
{
    public class ServiceFactoryBuilder<TService, TKey> where TService : class
    {
        private readonly IServiceCollection _services;
        private readonly FactoryTypes<TService, TKey> _factoryTypes;

        public ServiceFactoryBuilder(IServiceCollection services, FactoryTypes<TService, TKey> factoryTypes)
        {
            _services = services;
            _factoryTypes = factoryTypes;
        }

        public ServiceFactoryBuilder<TService, TKey> Add<TImplementation>(TKey p)
            where TImplementation : class, TService
        {
            _factoryTypes.ServiceList.Add(p, typeof(TImplementation));
            _services.AddTransient<TImplementation>();
            return this;
        }
    }

    public interface IFactory<TService, TKey>
    {
        TService Create(TKey p);
    }

    public class Factory<TService, TKey> : IFactory<TService, TKey> where TService : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly FactoryTypes<TService, TKey> _factoryTypes;
        public Factory(IServiceProvider serviceProvider, FactoryTypes<TService, TKey> factoryTypes)
        {
            _serviceProvider = serviceProvider;
            _factoryTypes = factoryTypes;
        }

        public TService Create(TKey p)
        {
            return (TService)_serviceProvider.GetService(_factoryTypes.ServiceList[p]);
        }
    }

    public class FactoryTypes<TService, TKey> where TService : class
    {
        public Dictionary<TKey, Type> ServiceList { get; set; } = new Dictionary<TKey, Type>();
    }
}
