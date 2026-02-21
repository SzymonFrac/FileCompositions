using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Specialized.Db.Context.Implementations;
using FileCompositions.Core.FileResource.Specialized.Db.Descriptor;
using FileCompositions.Core.FileResource.Specialized.Db.Descriptor.Implementations;
using FileCompositions.Core.FileResource.Specialized.Db.Implementations;
using FileCompositions.Core.FileResource.Specialized.Json.Context.Implementations;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized.Db.Builder.Implementations;

public class DbFileResourceBuilder(IFileResource baseFile) : IDbFileResourceBuilder
{
    private readonly IFileResource _baseFile = baseFile;

    IDbFileResource IDbFileResourceBuilder.Build(IDirectoryLocation directory)
    {
        var name = StorageResourceName.Create(_baseFile.Name, ".db");
        var context = new DbFileResourceContext(directory);

        var db = new DbFileResource(context, name);
        return db;
    }

    IDbFileResourceDescriptor IDbFileResourceBuilder.BuildDescriptor(DirectoryLocationKey key)
    {
        var name = StorageResourceName.Create(_baseFile.Name, ".db");

        var descriptor = new DbFileResourceDescriptor(key, name);
        return descriptor;
    }
}
