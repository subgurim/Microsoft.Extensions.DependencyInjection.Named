using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection.Exceptions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NamedServiceProvider
    {
        public static TService GetService<TService>(this IServiceProvider serviceProvider, string name)
        {
            var namedServiceSelector = serviceProvider.GetService<INamedServiceContainer>();

            if (namedServiceSelector != null)
            {
                if (namedServiceSelector.Dictionary.TryGetValue(typeof(TService), out var item))
                {
                    if (item.TryGetValue(name, out var implementationType))
                    {
                        return serviceProvider.GetServices<TService>().FirstOrDefault(t => t.GetType() == implementationType);
                    }
                }
            }

            throw new NotExistingNamedServiceException(typeof(TService).FullName, name);
        }
    }
}