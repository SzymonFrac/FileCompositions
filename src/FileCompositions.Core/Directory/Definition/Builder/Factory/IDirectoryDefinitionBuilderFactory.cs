using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.Implementations;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory;

internal interface IDirectoryDefinitionBuilderFactory
{
    IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, LocalDiskStorageBackend> CreateDefault();
    IDirectoryDefinitionBuilder<TOwnership, TNecessity, TBackend> Create<TOwnership, TNecessity, TBackend>()
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TBackend : class, IStorageBackend;
}
