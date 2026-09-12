using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Json.Name.Ext;

public static partial class FileNameExt
{
    extension(Filename)
    {
        public static Filename CreateJson(string name) =>
            Filename.Create(name, JsonDefinition.Extension);
        public static Filename CreateJson(ReadOnlySpan<char> name) =>
            Filename.Create(name, JsonDefinition.Extension);
    }
}
