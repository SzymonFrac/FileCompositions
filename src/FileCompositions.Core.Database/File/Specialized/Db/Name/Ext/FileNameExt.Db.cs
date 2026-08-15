using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.File.Name;

namespace FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;

public static partial class FileNameExt
{
    extension(FileName)
    {
        public static FileName CreateDb(string name) =>
            FileName.Create(name, DbDefinition.Extension);
        public static FileName CreateDb(ReadOnlySpan<char> name) =>
            FileName.Create(name, DbDefinition.Extension);
    }
}
