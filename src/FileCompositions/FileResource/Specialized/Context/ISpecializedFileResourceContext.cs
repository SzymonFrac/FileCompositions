using FileCompositions.Core.DirectoryLocation.StorageConnector;

namespace FileCompositions.Core.FileResource.Specialized.Context;

internal interface ISpecializedFileResourceContext
{
    IDirectoryLocationStorageConnector StorageConnector { get; }
}
