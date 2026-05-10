using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Extensions;

public static class StorageResourceNameAsJson
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateJson(string name) =>
            StorageResourceName.Create(name, JsonDefinition.Extension);
    }
}
