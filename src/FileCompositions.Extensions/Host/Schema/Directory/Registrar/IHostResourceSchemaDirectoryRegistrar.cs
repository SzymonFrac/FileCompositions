using FileCompositions.Core.Directory.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.Directory.Registrar;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Extensions.Host.Schema.Directory.Registries;

namespace FileCompositions.Extensions.Host.Schema.Directory.Registrar;

public interface IHostResourceSchemaDirectoryRegistrar : IResourceSchemaDirectoryRegistrar
{
    new IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity, TBackend>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;

    new IHostResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;

    internal IHostResourceSchemaDirectoryRegistries Build();
}