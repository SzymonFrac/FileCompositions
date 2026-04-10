using FileCompositions.Core.DirectoryLocation.StorageConnector;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Context.Implementations;

internal class JsonFileResourceContext(IDirectoryLocationStorageConnector storageConnector) : IJsonFileResourceContext
{
    public IDirectoryLocationStorageConnector StorageConnector { get; } = storageConnector;
}
