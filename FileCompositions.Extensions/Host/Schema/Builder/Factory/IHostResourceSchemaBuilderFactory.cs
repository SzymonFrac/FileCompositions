using FileCompositions.Core.Schema.StorageBackend.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Builder.Factory;

internal interface IHostResourceSchemaBuilderFactory
{
    IHostResourceSchemaBuilder Create(IResourceSchemaStorageBackendRegistrar storageBackendRegistrar,
        IHostResourceSchemaFileResourceRegistrar fileRegistrar, IServiceCollection settingServices);
}
