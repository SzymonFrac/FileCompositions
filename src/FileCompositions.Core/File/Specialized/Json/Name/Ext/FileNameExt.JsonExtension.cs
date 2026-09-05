using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.File.Specialized.Json.Name.Ext;

public static partial class FileNameExt
{
    extension(FileSystemFilename)
    {
        public static FileSystemFilename CreateJson(string name) =>
            FileSystemFilename.Create(name, JsonDefinition.Extension);
        public static FileSystemFilename CreateJson(ReadOnlySpan<char> name) =>
            FileSystemFilename.Create(name, JsonDefinition.Extension);
    }
}
