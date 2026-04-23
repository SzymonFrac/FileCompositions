using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Resource.Context;

internal interface IFileResourceContext
{
    IDirectoryStorageConnector StorageConnector { get; }
}
