using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Extensions;

public static class StorageResourceNameAsDll
{
    extension(FileSystemResourceName)
    {
        public static FileSystemResourceName CreateDll(string name) =>
            FileSystemResourceName.Create(name, DllDefinition.Extension);
    }
}
