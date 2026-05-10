using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Storage.Backend;

public interface IStorageBackend
{
    Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask CreateAddress(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask CreateResource(StorageLocation location, CancellationToken cancellationToken = default);

    IAsyncEnumerable<StorageResourceName> EnumerateResourceNames(StorageAddress address, CancellationToken cancellationToken = default);
}
