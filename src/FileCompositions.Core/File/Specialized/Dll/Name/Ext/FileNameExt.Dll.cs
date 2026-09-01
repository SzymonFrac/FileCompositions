using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.File.Specialized.Dll.Name.Ext;

public static partial class FileNameExt
{
    extension(FileSystemFilename)
    {
        public static FileSystemFilename CreateDll(string name) =>
            FileSystemFilename.Create(name, DllDefinition.Extension);
        public static FileSystemFilename CreateDll(ReadOnlySpan<char> name) =>
            FileSystemFilename.Create(name, DllDefinition.Extension);
    }
}
