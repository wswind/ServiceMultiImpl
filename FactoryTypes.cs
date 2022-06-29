namespace ServiceMultiImpl
{
    public class FactoryTypes<TService, TKey> where TService : class
    {
        public Dictionary<TKey, Type> ServiceList { get; set; } = new Dictionary<TKey, Type>();
    }
}
