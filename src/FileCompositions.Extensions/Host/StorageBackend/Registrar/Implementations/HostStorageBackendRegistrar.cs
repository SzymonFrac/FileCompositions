using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.StorageBackend.Register.Definition;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Registrar.Implementations;

internal class HostStorageBackendRegistrar : IResourceSchemaStorageBackendRegistrar
{
    private readonly HashSet<HostStorageBackendRegisterDefinition> _registries = [];
    public IResourceSchemaStorageBackendRegistrar Register<TBackend>()
        where TBackend : class, IStorageBackend
    {
        var register = new HostStorageBackendRegisterDefinition((ref services) => services.AddSingleton<TBackend>());
        _registries.Add(register);

        return this;
    }

    public void Register(ref IServiceCollection services)
    {
        foreach (var registry in _registries)
            registry(ref services);
    }
}
