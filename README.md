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

