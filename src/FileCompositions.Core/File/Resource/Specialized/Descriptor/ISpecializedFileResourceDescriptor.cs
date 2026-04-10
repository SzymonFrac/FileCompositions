using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Specialized.Descriptor;

internal interface ISpecializedFileResourceDescriptor
{
    DirectoryLocationKey DirectoryLocationKey { get; }
    StorageResourceName Name { get; }
    ISpecializedFileResource Activate(IDirectoryLocation directory);
}
