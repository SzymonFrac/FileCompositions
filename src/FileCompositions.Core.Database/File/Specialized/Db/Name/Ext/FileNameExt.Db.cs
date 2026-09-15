using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;

public static partial class FileNameExt
{
    extension(Filename)
    {
        public static Filename CreateDb(string name) =>
            Filename.Create(name, DbDefinition.Extension);
        public static Filename CreateDb(ReadOnlySpan<char> name) =>
            Filename.Create(name, DbDefinition.Extension);
    }
}
