using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class StorageResourceNameAsJson
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateJson(string name) =>
            StorageResourceName.Create(name, JsonDefinition.Extension);
    }
}
