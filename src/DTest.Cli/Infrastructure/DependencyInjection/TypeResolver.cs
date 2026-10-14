using Spectre.Console.Cli;

namespace DTest.Infrastructure.DependencyInjection;


public sealed class TypeResolver(IServiceProvider provider) : ITypeResolver
{
    public object? Resolve(Type? type) => type == null ? null : provider.GetService(type);
}
