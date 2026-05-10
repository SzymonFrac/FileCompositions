using FileCompositions.Core.ResourceSchema.Builder;
using FileCompositions.Core.ResourceSchema.File.Definition.Registrar;
using FileCompositions.Core.ResourceSchema.StorageBackend.Registrar;
using FileCompositions.Extensions.Host.Schema.Directory.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Builder;

public interface IHostResourceSchemaBuilder : IResourceSchemaBuilder
{
    new IHostResourceSchemaBuilder ConfigureStorageBackends(Action<IResourceSchemaStorageBackendRegistrar> config);
    new IHostResourceSchemaBuilder ConfigureDefinitions(Action<IResourceSchemaFileDefinitionRegistrar> config);

    //IHostResourceSchemaBuilder ConfigureRoots(Action<IHostResourceSchemaResourcesContextBuilder> config);
    //IHostResourceSchemaBuilder ConfigureResources(Action<IHostResourceSchemaResourcesRegistrar, IHostResourceSchemaResourcesContextProvider> config);
    IHostResourceSchemaBuilder ConfigureRegistries(Action<IHostResourceSchemaDirectoryRegistrar> config);
    internal IHostResourceSchema Build(in IServiceCollection services);
}
