using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.StorageConnector;

internal interface IDirectoryLocationStorageConnector
{
    Task<Stream> OpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    ValueTask<bool> Exists(StorageResourceName name, CancellationToken cancellationToken = default);
}
