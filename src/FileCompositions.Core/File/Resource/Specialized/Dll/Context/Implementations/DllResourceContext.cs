using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Context.Implementations;

internal class DllResourceContext(IDirectoryStorageConnector storageConnector) : IDllResourceContext
{
    public IDirectoryStorageConnector StorageConnector { get; } = storageConnector;
}
