using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateDb(string name) =>
            FileSystemResourceName.Create(name, DbDefinition.Extension);
    }
}
