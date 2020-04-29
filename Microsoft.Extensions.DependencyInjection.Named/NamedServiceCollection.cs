using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection.Exceptions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NamedServiceCollection
    {
        public static IServiceCollection Add(this IServiceCollection collection, Type serviceType, Type implementationType, string name, ServiceLifetime lifetime)
        {
            var serviceProvider = collection.BuildServiceProvider();
            var namedServiceSelector = serviceProvider.GetService<INamedServiceContainer>();

            if (namedServiceSelector != null)
            {
                if (namedServiceSelector.Dictionary.TryGetValue(serviceType, out var item))
                {
                    if (item.TryGetValue(name, out var alredyRegisteredImplementationType))
                    {
                        throw new AlreadyRegisteredNameForServiceTypeException(name, serviceType.FullName, alredyRegisteredImplementationType.FullName);
                    }

                    item.Add(name, implementationType);
                }
                else
                {
                    namedServiceSelector.Dictionary.Add(serviceType, new Dictionary<string, Type> {{name, implementationType}});
                }
            }
            else
            {
                var dictionary = new Dictionary<Type, Dictionary<string, Type>>
                {
                    {serviceType, new Dictionary<string, Type> {{name, implementationType}}}
                };

                collection.AddSingleton<INamedServiceContainer>(servicesProvider => new NamedServiceContainer(dictionary));
            }

            collection.Add(new ServiceDescriptor(serviceType, implementationType, lifetime));

            return collection;
        }
    }
}