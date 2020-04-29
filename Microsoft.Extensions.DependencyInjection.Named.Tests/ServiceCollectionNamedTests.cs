using Microsoft.Extensions.DependencyInjection.Exceptions;
using NUnit.Framework;

namespace Microsoft.Extensions.DependencyInjection.Named.Tests
{
    public class ServiceCollectionNamedTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NamedServicesTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceA), "A", ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceB), "B", ServiceLifetime.Transient);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var myServiceA = serviceProvider.GetService<IMyService>("A");
            Assert.NotNull(myServiceA);
            Assert.IsInstanceOf<MyServiceA>(myServiceA);

            var myServiceB = serviceProvider.GetService<IMyService>("B");
            Assert.NotNull(myServiceB);
            Assert.IsInstanceOf<MyServiceB>(myServiceB);
        }
        
        [Test]
        public void SameNamedServiceThrowsException()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceA), "A", ServiceLifetime.Transient);
            Assert.Throws<AlreadyRegisteredNameForServiceTypeException>(() => serviceCollection.Add(typeof(IMyService), typeof(MyServiceB), "A", ServiceLifetime.Transient));
        }
        
        [Test]
        public void NotExistingNamedServiceThrowsException()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceA), "A", ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IMyService), typeof(MyServiceB), "B", ServiceLifetime.Transient);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Assert.Throws<NotExistingNamedServiceException>(() => serviceProvider.GetService<IMyService>("C"));
        }
    }
}