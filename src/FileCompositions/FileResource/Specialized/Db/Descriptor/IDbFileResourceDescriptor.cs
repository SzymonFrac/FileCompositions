using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.FileResource.Specialized.Descriptor;

namespace FileCompositions.Core.FileResource.Specialized.Db.Descriptor;

internal interface IDbFileResourceDescriptor : ISpecializedFileResourceDescriptor
{
    new IDbFileResource Activate(IDirectoryLocation directory);
}
