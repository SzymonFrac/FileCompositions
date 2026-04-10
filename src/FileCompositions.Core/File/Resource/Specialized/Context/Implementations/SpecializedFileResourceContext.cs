using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.StorageConnector;

namespace FileCompositions.Core.File.Resource.Specialized.Context.Implementations;

internal class SpecializedFileResourceContext(IDirectoryLocation directoryLocation) : ISpecializedFileResourceContext
{
    public IDirectoryLocationStorageConnector StorageConnector { get; } = directoryLocation;
}
