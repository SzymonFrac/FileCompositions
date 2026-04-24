using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Context.Implementations;

internal class FileContext(IDirectoryLocation directoryLocation) : IFileContext
{
    public IDirectoryStorageConnector StorageConnector { get; } = directoryLocation;
}
