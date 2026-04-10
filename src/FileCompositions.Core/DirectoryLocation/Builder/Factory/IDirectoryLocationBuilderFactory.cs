using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Builder.Factory;

internal interface IDirectoryLocationBuilderFactory
{
    IDirectoryLocationBuilder<StrictDefinition, RequiredDefinition> CreateDefault(IStorageBackendProvider storageBackend, IFileLocationResolver resolver);
    IDirectoryLocationBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>(IStorageBackendProvider storageBackend, IFileLocationResolver resolver)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
}
