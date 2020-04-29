using System;

namespace Microsoft.Extensions.DependencyInjection.FactoryPattern
{
    public static class FactoryPatternHelpers
    {
        public static string GetName<TEnum>(this TEnum @enum)
            where TEnum : Enum
        {
            return $"{@enum.GetType().FullName}-@{Convert.ToInt32(@enum).ToString()}";
        }
    }
}