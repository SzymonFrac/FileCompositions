using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.ResourceStream;

internal interface IOptionalDirectoryLocationResourceStream
{
    Task<Stream?> TryOpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    Task<Stream?> TryOpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default);
}
