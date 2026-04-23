using FileCompositions.Extensions.Host.Schema.Directory.Register;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace FileCompositions.Extensions.Host.Schema.Directory.Registries.Implementations;

internal class HostResourceSchemaDirectoryRegistries(IReadOnlyList<HostResourceSchemaDirectoryRegister> registries) : IHostResourceSchemaDirectoryRegistries
{
    private readonly IReadOnlyList<HostResourceSchemaDirectoryRegister> _registries = registries;

    public void Register(ref IServiceCollection services)
    {
        foreach (var registry in _registries)
            registry(ref services);
    }

    public IEnumerator<HostResourceSchemaDirectoryRegister> GetEnumerator() => _registries.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
