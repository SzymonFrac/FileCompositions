using FileCompositions.Core.File.Definition.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Json.Extensions;

public static class StorageResourceNameJsonDefinitionExtensions
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateJson(string name) =>
            StorageResourceName.Create(name, JsonDefinition<object>.Extension);
    }
}
