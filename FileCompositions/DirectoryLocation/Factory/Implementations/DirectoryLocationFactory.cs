using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Descriptor.Implementations;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Factory.Implementations;

internal class DirectoryLocationFactory : IDirectoryLocationFactory
{
    public IDirectoryLocation Create(IDirectoryLocationContext context, StorageAddress address) =>
        new DirectoryLocation.Implementations.DirectoryLocation(context, address);

    public IDirectoryLocationDescriptor Create(DirectoryLocationKey key, IStorageBackendProvider backendProvider, StorageAddress address) =>
        new DirectoryLocationDescriptor(key, backendProvider, address);
}
