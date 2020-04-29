using System;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;

namespace Microsoft.Extensions.DependencyInjection.Named.Tests.Objects
{
    public class MyServiceFactoryPatternResolver : FactoryPatternResolver<IMyService, MyEnum>, IMyServiceFactoryPatternResolver
    {
        public MyServiceFactoryPatternResolver(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
    }
}