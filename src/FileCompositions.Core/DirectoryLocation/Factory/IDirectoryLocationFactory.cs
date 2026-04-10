using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Factory;

internal interface IDirectoryLocationFactory
{
    IDirectoryLocation Create<TOwnership, TNecessity>(IDirectoryLocationContext context, StorageAddress address)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
    IDirectoryLocationDescriptor Create(DirectoryLocationKey key, IStorageBackendProvider backendProvider, StorageAddress address);
}
