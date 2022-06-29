using ServiceMultiImpl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static FactoryBuilder<I, P> AddFactory<I, P>(this IServiceCollection services)
            where I : class
        {
            services.AddTransient<IFactory<I, P>, Factory<I, P>>();
            return new FactoryBuilder<I, P>(services);
        }
    }
}