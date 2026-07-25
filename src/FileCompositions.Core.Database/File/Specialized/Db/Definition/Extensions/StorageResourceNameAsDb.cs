using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Extensions;

public static class StorageResourceNameAsDb
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateDb(string name) =>
            FileSystemResourceName.Create(name, DbDefinition.Extension);
    }
}
