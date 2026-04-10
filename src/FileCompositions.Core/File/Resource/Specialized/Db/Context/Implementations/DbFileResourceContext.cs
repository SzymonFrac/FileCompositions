using FileCompositions.Core.DirectoryLocation.StorageConnector;
using FileCompositions.Core.File.Resource.Specialized.Db.Context;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Context.Implementations;

internal class DbFileResourceContext(IDirectoryLocationStorageConnector storageConnector) : IDbFileResourceContext
{
    public IDirectoryLocationStorageConnector StorageConnector { get; } = storageConnector;
}
