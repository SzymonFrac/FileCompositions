using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Specialized.Db.Descriptor;

namespace FileCompositions.Core.FileResource.Specialized.Db.Builder;

public interface IDbFileResourceBuilder
{
    internal IDbFileResource Build(IDirectoryLocation directory);
    internal IDbFileResourceDescriptor BuildDescriptor(DirectoryLocationKey key);
}
