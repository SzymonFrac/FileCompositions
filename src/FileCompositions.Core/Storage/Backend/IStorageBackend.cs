using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.Storage.Backend;

public interface IStorageBackend
{
    Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenAppendAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenCreateAsync(StorageLocation location, CancellationToken cancellationToken = default);

    ValueTask<bool> ExistsAsync(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask<bool> ExistsAsync(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask CreateAsync(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask CreateAsync(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask DeleteAsync(StorageAddress address, CancellationToken cancellationToken = default);
    ValueTask DeleteAsync(StorageLocation location, CancellationToken cancellationToken = default);
}
