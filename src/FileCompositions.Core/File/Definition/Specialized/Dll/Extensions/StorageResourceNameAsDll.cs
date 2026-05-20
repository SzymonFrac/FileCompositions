using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;

public static class StorageResourceNameAsDll
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateDll(string name) =>
            StorageResourceName.Create(name, DllDefinition.Extension);
    }
}
