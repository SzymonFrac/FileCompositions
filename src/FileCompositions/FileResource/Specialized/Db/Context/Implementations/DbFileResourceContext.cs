using FileCompositions.Core.DirectoryLocation.StorageConnector;

namespace FileCompositions.Core.FileResource.Specialized.Db.Context.Implementations;

internal class DbFileResourceContext(IDirectoryLocationStorageConnector storageConnector) : IDbFileResourceContext
{
    public IDirectoryLocationStorageConnector StorageConnector { get; } = storageConnector;
}
