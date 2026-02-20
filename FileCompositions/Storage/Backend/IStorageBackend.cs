using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.Storage.Backend;

public interface IStorageBackend
{
    Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default);
    ValueTask CreateAddress(StorageAddress address, CancellationToken cancellationToken = default);
}
