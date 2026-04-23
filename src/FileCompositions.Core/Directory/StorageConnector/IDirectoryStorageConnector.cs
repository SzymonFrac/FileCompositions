using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.StorageConnector;

internal interface IDirectoryStorageConnector
{
    Task<Stream> OpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageResourceName name, CancellationToken cancellationToken = default);

    StorageLocation GetLocation(StorageResourceName name);
}
