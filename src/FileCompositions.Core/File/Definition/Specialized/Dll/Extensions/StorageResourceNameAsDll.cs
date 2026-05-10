using FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;

public static class StorageResourceNameAsDll
{
    extension(StorageResourceName)
    {
        public static StorageResourceName CreateDll(string name) =>
            StorageResourceName.Create(name, DllDefinition.Extension);
    }
}
