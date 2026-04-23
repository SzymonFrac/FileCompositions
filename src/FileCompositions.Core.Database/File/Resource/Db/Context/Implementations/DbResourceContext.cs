using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.Database.File.Resource.Db.Context.Implementations;

internal class DbResourceContext(IDirectoryStorageConnector storageConnector) : IDbResourceContext
{
    public IDirectoryStorageConnector StorageConnector { get; } = storageConnector;
}
