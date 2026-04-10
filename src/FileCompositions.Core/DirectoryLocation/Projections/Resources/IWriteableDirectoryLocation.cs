using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.Projections.Resources;

public interface IWriteableDirectoryLocation
{
    internal ValueTask CreateResource(StorageResourceName name, CancellationToken cancellationToken = default);
    internal ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken = default);
}
