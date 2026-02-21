using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Factory;

internal interface IDirectoryLocationFactory
{
    IDirectoryLocation Create(IDirectoryLocationContext context, StorageAddress address);
    IDirectoryLocationDescriptor Create(DirectoryLocationKey key, IStorageBackendProvider backendProvider, StorageAddress address);
}
