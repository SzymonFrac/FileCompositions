using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.Projections.Resources;

public interface IWriteableDirectory
{
    internal ValueTask CreateResource(StorageResourceName name, CancellationToken cancellationToken = default);
    internal ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken = default);
}
