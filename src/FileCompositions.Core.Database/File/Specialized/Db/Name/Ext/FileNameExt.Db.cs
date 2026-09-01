using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;

public static partial class FileNameExt
{
    extension(FileSystemFilename)
    {
        public static FileSystemFilename CreateDb(string name) =>
            FileSystemFilename.Create(name, DbDefinition.Extension);
        public static FileSystemFilename CreateDb(ReadOnlySpan<char> name) =>
            FileSystemFilename.Create(name, DbDefinition.Extension);
    }
}
