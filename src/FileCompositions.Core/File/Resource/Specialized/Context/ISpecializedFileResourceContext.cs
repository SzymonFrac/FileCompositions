using FileCompositions.Core.DirectoryLocation.StorageConnector;

namespace FileCompositions.Core.File.Resource.Specialized.Context;

internal interface ISpecializedFileResourceContext
{
    IDirectoryLocationStorageConnector StorageConnector { get; }
}
