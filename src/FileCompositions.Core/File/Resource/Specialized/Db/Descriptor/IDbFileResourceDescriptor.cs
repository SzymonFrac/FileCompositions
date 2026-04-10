using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Resource.Specialized.Db;
using FileCompositions.Core.File.Resource.Specialized.Descriptor;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Descriptor;

internal interface IDbFileResourceDescriptor : ISpecializedFileResourceDescriptor
{
    new IDbFileResource Activate(IDirectoryLocation directory);
}
