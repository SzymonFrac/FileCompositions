using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Database.File.Definition.Db.Extensions;

public static class StorageResourceNameAsDb
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateDb(string name) =>
            StorageResourceName.Create(name, DbDefinition.Extension);
    }
}
