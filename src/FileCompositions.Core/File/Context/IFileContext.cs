using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IDirectoryStorageConnector StorageConnector { get; }
}
