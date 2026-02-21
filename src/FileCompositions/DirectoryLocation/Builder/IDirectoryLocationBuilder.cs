using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Factory;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.ActivationContext;

namespace FileCompositions.Core.DirectoryLocation.Builder;

public interface IDirectoryLocationBuilder
{
    IDirectoryLocationBuilder WithAddress(StorageAddress address);
    IDirectoryLocationBuilder ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend;
    internal IDirectoryLocationBuilder UseFactory(IDirectoryLocationFactory factory);
    internal IDirectoryLocation Build(IStorageBackendActivationContext context);
    internal IDirectoryLocationDescriptor BuildDescriptor(DirectoryLocationKey key);
}
