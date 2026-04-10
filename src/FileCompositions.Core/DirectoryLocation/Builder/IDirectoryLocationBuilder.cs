using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.ActivationContext;

namespace FileCompositions.Core.DirectoryLocation.Builder;

public interface IDirectoryLocationBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IDirectoryLocationBuilder<TOwnership, TNecessity> WithAddress(StorageAddress address);
    IDirectoryLocationBuilder<TOwnership, TNecessity> ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend;

    IDirectoryLocationBuilder<ExternalDefinition, TNecessity> External();
    IDirectoryLocationBuilder<StrictDefinition, TNecessity> Strict();
    IDirectoryLocationBuilder<TOwnership, RequiredDefinition> Required();
    IDirectoryLocationBuilder<TOwnership, OptionalDefinition> Optional();

    internal IDirectoryLocation Build(IStorageBackendActivationContext context);
    internal IDirectoryLocationDescriptor BuildDescriptor(DirectoryLocationKey key);
}
