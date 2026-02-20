using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized.Descriptor;

internal interface ISpecializedFileResourceDescriptor
{
    DirectoryLocationKey DirectoryLocationKey { get; }
    StorageResourceName Name { get; }
    ISpecializedFileResource Activate(IDirectoryLocation directory);
}
