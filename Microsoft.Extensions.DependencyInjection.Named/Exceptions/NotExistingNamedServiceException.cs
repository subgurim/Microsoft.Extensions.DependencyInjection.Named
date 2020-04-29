using System;

namespace Microsoft.Extensions.DependencyInjection.Exceptions
{
    public class NotExistingNamedServiceException : Exception
    {
        public NotExistingNamedServiceException(string serviceType, string name) : base($"There's no service of type {serviceType} named as {name}")
        {
        }
    }
}