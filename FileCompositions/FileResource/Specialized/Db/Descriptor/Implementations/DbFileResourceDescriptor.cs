using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Specialized.Db.Context.Implementations;
using FileCompositions.Core.FileResource.Specialized.Db.Implementations;
using FileCompositions.Core.FileResource.Specialized.Descriptor;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized.Db.Descriptor.Implementations;

internal class DbFileResourceDescriptor(DirectoryLocationKey key, StorageResourceName name) : IDbFileResourceDescriptor
{
    public DirectoryLocationKey DirectoryLocationKey { get; } = key;
    public StorageResourceName Name { get; } = name;

    public IDbFileResource Activate(IDirectoryLocation directory)
    {
        var context = new DbFileResourceContext(directory);
        var db = new DbFileResource(context, Name);
        return db;
    }

    ISpecializedFileResource ISpecializedFileResourceDescriptor.Activate(IDirectoryLocation directory) => Activate(directory);
}
