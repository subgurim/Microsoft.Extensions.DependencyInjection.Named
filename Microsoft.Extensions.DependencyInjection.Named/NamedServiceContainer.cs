using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public class NamedServiceContainer : INamedServiceContainer
    {
        public NamedServiceContainer(Dictionary<Type, Dictionary<string, Type>> dictionary)
        {
            Dictionary = dictionary;
        }

        public Dictionary<Type, Dictionary<string, Type>> Dictionary { get; }
    }
}