using FileCompositions.Core.Database.File.Definition.Db.Abstract;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Database.File.Definition.Db.Extensions;

public static class StorageResourceNameAsDb
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateDb(string name) =>
            StorageResourceName.Create(name, DbDefinition.Extension);
    }
}
