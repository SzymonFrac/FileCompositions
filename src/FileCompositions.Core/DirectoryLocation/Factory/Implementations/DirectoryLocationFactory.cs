using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Descriptor.Implementations;
using FileCompositions.Core.DirectoryLocation.Implementations;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Factory.Implementations;

internal class DirectoryLocationFactory : IDirectoryLocationFactory
{
    public IDirectoryLocation Create<TOwnership, TNecessity>(IDirectoryLocationContext context, StorageAddress address)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity =>
            new DirectoryLocation<TOwnership, TNecessity>(context, address);

    public IDirectoryLocationDescriptor Create(DirectoryLocationKey key, IStorageBackendProvider backendProvider, StorageAddress address) =>
        new DirectoryLocationDescriptor(key, backendProvider, address);
}
