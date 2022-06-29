//generic factory from https://stackoverflow.com/a/59338701/7726468 author is 'T Brown'
//licence: CC BY-SA 4.0

namespace ServiceMultiImpl
{
    public class FactoryBuilder<TService, TKey> where TService : class
    {
        private readonly IServiceCollection _services;
        private readonly FactoryTypes<TService, TKey> _factoryTypes;
        public FactoryBuilder(IServiceCollection services)
        {
            _services = services;
            _factoryTypes = new FactoryTypes<TService, TKey>();
            _services.AddSingleton(_factoryTypes);
        }
        public FactoryBuilder<TService, TKey> Add<TImplementation>(TKey p)
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
