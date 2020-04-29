using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public interface INamedServiceContainer
    {
        Dictionary<Type, Dictionary<string, Type>> Dictionary { get; }
    }
}