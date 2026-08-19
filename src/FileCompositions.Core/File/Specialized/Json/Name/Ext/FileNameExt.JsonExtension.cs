using FileCompositions.Core.File.Name;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Name.Ext;

public static partial class FileNameExt
{
    extension(FileName)
    {
        public static FileName CreateJson(string name) =>
            FileName.Create(name, JsonDefinition.Extension);
        public static FileName CreateJson(ReadOnlySpan<char> name) =>
            FileName.Create(name, JsonDefinition.Extension);
    }
}
