using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.File.Resource.Specialized.Db;
using FileCompositions.Core.File.Resource.Specialized.Db.Descriptor;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Builder;

public interface IDbFileResourceBuilder
{
    internal IDbFileResource Build(IDirectoryLocation directory);
    internal IDbFileResourceDescriptor BuildDescriptor(DirectoryLocationKey key);
}
