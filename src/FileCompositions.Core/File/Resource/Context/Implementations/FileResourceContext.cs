using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.Directory.StorageConnector;

namespace FileCompositions.Core.File.Resource.Context.Implementations;

internal class FileResourceContext(IDirectoryLocation directoryLocation) : IFileResourceContext
{
    public IDirectoryStorageConnector StorageConnector { get; } = directoryLocation;
}
