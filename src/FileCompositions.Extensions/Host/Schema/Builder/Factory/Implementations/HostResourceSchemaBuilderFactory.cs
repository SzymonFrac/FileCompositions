using FileCompositions.Core.Schema.StorageBackend.Registrar;
using FileCompositions.Extensions.Host.Schema.Builder.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Builder.Factory.Implementations;

internal class HostResourceSchemaBuilderFactory : IHostResourceSchemaBuilderFactory
{
    public IHostResourceSchemaBuilder Create(IResourceSchemaStorageBackendRegistrar storageBackendRegistrar,
        IHostResourceSchemaFileResourceRegistrar fileRegistrar, IServiceCollection settingServices) =>
            new HostResourceSchemaBuilder(storageBackendRegistrar, fileRegistrar, settingServices);
}
