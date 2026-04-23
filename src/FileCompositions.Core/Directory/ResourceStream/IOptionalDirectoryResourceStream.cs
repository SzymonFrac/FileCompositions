using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.ResourceStream;

internal interface IOptionalDirectoryResourceStream
{
    Task<Stream?> TryOpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    Task<Stream?> TryOpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default);
}
