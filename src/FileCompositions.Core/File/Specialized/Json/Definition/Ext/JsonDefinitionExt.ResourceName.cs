using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Ext;

public static partial class JsonDefinitionExt
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateJson(string name) =>
            FileSystemResourceName.Create(name, JsonDefinition.Extension);
    }
}
