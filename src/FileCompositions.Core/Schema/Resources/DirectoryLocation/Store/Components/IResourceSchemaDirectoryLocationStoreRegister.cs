using FileCompositions.Core.DirectoryLocation.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Schema.Resources.DirectoryLocation.Store.Components;

public interface IResourceSchemaDirectoryLocationStoreRegister
{
    void Register<TOwnership, TNecessity>(Action<IDirectoryLocationBuilder<TOwnership, TNecessity>> config)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
