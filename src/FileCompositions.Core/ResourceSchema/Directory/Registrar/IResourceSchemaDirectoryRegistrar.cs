using FileCompositions.Core.Directory.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.ResourceSchema.Directory.Registrar;

public interface IResourceSchemaDirectoryRegistrar
{
    IResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity, TBackend>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;

    IResourceSchemaDirectoryRegistrar Store<TOwnership, TNecessity>(ResourceSchemaDirectoryConfig<TOwnership, TNecessity> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
