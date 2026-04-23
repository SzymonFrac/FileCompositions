using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Context.Implementations;

internal class JsonResourceContext(IDirectoryStorageConnector storageConnector) : IJsonResourceContext
{
    public IDirectoryStorageConnector StorageConnector { get; } = storageConnector;
}
