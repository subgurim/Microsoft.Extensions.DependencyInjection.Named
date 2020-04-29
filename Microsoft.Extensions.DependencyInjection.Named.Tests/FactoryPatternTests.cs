using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using Microsoft.Extensions.DependencyInjection.Named.Tests.Objects;
using NUnit.Framework;

namespace Microsoft.Extensions.DependencyInjection.Named.Tests
{
    [TestFixture]
    public class FactoryPatternTests
    {
        [Test]
        public void FactoryPatternTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceA), MyEnum.A.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceB), MyEnum.B.GetName(), ServiceLifetime.Transient);

            serviceCollection.AddTransient<IMyServiceFactoryPatternResolver, MyServiceFactoryPatternResolver>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var factoryPatternResolver = serviceProvider.GetService<IMyServiceFactoryPatternResolver>();
            
            var myServiceA = factoryPatternResolver.Resolve(MyEnum.A);
            Assert.NotNull(myServiceA);
            Assert.IsInstanceOf<MyServiceA>(myServiceA);
            
            var myServiceB = factoryPatternResolver.Resolve(MyEnum.B);
            Assert.NotNull(myServiceB);
            Assert.IsInstanceOf<MyServiceB>(myServiceB);
        }
    }
}