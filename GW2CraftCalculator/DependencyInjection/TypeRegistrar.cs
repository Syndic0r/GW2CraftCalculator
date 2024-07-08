using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace GW2CraftCalculator.DependencyInjection;

public sealed class TypeRegistrar : ITypeRegistrar
{
    private IServiceCollection _builder;

    public TypeRegistrar(IServiceCollection builder)
    {
        _builder = CopyServiceCollection(builder);
    }

    public ITypeResolver Build()
    {
        return new TypeResolver(_builder.BuildServiceProvider());
    }

    public void Register(Type service, Type implementation)
    {
        _builder.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        _builder.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        _builder.AddSingleton(service, (provider) => func());
    }

    private static IServiceCollection CopyServiceCollection(IServiceCollection serviceCollection)
    {
        IServiceCollection collection = new ServiceCollection();

        foreach (ServiceDescriptor serviceDescriptor in serviceCollection)
        {
            collection.Add(serviceDescriptor);
        }

        return collection;
    }
}
