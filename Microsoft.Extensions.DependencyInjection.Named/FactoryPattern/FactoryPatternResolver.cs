using System;

namespace Microsoft.Extensions.DependencyInjection.FactoryPattern
{
    public abstract class FactoryPatternResolver<TService, TEnum>
        : IFactoryPatternResolver<TService, TEnum>
        where TEnum : Enum
    {
        private readonly IServiceProvider _serviceProvider;

        protected FactoryPatternResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TService Resolve(TEnum @enum)
        {
            return _serviceProvider.GetService<TService>(@enum.GetName());
        }
    }
}