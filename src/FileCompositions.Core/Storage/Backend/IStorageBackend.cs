using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Storage.Backend;

public interface IStorageBackend
{
    Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask Create(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask Create(StorageLocation location, CancellationToken cancellationToken = default);

    IAsyncEnumerable<StorageResourceName> EnumerateResources(StorageAddress address, CancellationToken cancellationToken = default);
}
