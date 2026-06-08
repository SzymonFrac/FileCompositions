using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class StorageResourceNameAsJson
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateJson(string name) =>
            FileSystemResourceName.Create(name, JsonDefinition.Extension);
    }
}
