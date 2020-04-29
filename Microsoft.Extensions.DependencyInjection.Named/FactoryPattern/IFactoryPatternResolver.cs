using System;

namespace Microsoft.Extensions.DependencyInjection.FactoryPattern
{
    public interface IFactoryPatternResolver<out TService, in TEnum>
        where TEnum : Enum
    {
        TService Resolve(TEnum @enum);
    }
}