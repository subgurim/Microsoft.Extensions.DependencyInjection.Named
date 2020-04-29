# Subgurim.Microsoft.Extensions.DependencyInjection.Named

Hacky implementation of named services for **Microsoft.Extensions.DependencyInjection**

Here's the nuget package: [https://www.nuget.org/packages/Subgurim.Microsoft.Extensions.DependencyInjection.Named](https://www.nuget.org/packages/Subgurim.Microsoft.Extensions.DependencyInjection.Named/)

Example of use:

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

It also allows you to easyly implement a "factory pattern" like this:

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

    public interface IMyServiceFactoryPatternResolver : IFactoryPatternResolver<IMyService, MyEnum>
    {
    }

    public class MyServiceFactoryPatternResolver : FactoryPatternResolver<IMyService, MyEnum>, IMyServiceFactoryPatternResolver
    {
        public MyServiceFactoryPatternResolver(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }
    }

    public enum MyEnum
    {
        A = 1,
        B = 2
    }
