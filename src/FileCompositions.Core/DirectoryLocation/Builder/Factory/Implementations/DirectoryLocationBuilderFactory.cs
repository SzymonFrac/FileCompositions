using FileCompositions.Core.DirectoryLocation.Builder.Implementations;
using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Builder.Factory.Implementations;

internal class DirectoryLocationBuilderFactory : IDirectoryLocationBuilderFactory
{
    public IDirectoryLocationBuilder<StrictDefinition, RequiredDefinition> CreateDefault(IStorageBackendProvider storageBackend, IFileLocationResolver resolver) =>
        new DirectoryLocationBuilder<StrictDefinition, RequiredDefinition>(storageBackend, resolver);
    public IDirectoryLocationBuilder<TOwnership, TNecessity> Create<TOwnership, TNecessity>(IStorageBackendProvider storageBackend, IFileLocationResolver resolver)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DirectoryLocationBuilder<TOwnership, TNecessity>(storageBackend, resolver);
}
