using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.StorageBackend.Registrar.Implementations;

internal sealed class HostResourceSchemaStorageBackendRegistrar : IHostResourceSchemaStorageBackendRegistrar
{
    private HostResourceSchemaRegister? register;

    public IResourceSchemaStorageBackendRegistrar Register<TBackend>()
        where TBackend : class, IStorageBackend
    {
        register += (in services) => services.AddSingleton<TBackend>();

        return this;
    }
    public HostResourceSchemaRegister? Build() => register;
}

