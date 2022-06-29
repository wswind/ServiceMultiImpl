//Origin Author is 'T Brown' from https://stackoverflow.com/a/59338701/7726468
//Licence: CC BY-SA 4.0
//Updated by Vincent Wang https://github.com/wswind/ServiceMultiImpl

namespace ServiceMultiImpl
{
    public interface IMultiImplServiceFactory<TService, TKey>
    {
        TService Create(TKey p);
    }

    public class MultiImplServiceFactory<TService, TKey> : IMultiImplServiceFactory<TService, TKey> where TService : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MultiImplTypeMapper<TService, TKey> _factoryTypes;
        public MultiImplServiceFactory(IServiceProvider serviceProvider, MultiImplTypeMapper<TService, TKey> factoryTypes)
        {
            _serviceProvider = serviceProvider;
            _factoryTypes = factoryTypes;
        }

        public TService Create(TKey key)
        {
            var implType = _factoryTypes.GetType(key);
            if (implType == null)
                return default;

            return (TService)_serviceProvider.GetService(implType);
        }
    }

    public class MultiImplTypeMapper<TService, TKey> where TService : class
    {
        public Dictionary<TKey, Type> ServiceList { get; set; } = new Dictionary<TKey, Type>();

        public Type GetType(TKey key)
        {
            var exist = ServiceList.TryGetValue(key, out Type implType);
            return exist ? implType : null;
        }
    }
}
