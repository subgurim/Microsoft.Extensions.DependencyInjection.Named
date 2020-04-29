using Microsoft.Extensions.DependencyInjection.FactoryPattern;

namespace Microsoft.Extensions.DependencyInjection.Named.Tests.Objects
{
    public interface IMyServiceFactoryPatternResolver : IFactoryPatternResolver<IMyService, MyEnum>
    {
    }
}