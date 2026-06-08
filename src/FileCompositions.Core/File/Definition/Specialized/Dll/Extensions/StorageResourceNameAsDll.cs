using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Extensions;

public static class StorageResourceNameAsDll
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateDll(string name) =>
            FileSystemResourceName.Create(name, DllDefinition.Extension);
    }
}
