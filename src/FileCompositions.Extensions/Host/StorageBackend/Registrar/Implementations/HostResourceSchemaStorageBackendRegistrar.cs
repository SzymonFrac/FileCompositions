using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Registrar.Implementations;

internal class HostResourceSchemaStorageBackendRegistrar : IHostResourceSchemaStorageBackendRegistrar
{
    private HostResourceSchemaRegister? register;

    public IResourceSchemaStorageBackendRegistrar Register<TBackend>()
        where TBackend : class, IStorageBackend
    {
        register += new HostResourceSchemaRegister((in services) => services.AddSingleton<TBackend>());

        return this;
    }
    public HostResourceSchemaRegister? Build() => register;
}

