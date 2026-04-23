using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder;

public interface IDirectoryLocationBuilder
{
    IDirectoryLocationBuilder WithAddress(StorageAddress address);
    IDirectoryLocationBuilder ToStorageBackend<TStorageBackend>()
        where TStorageBackend : class, IStorageBackend, new();

    internal IDirectoryLocation Build();
}
