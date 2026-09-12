using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Dll.Name.Ext;

public static partial class FileNameExt
{
    extension(Filename)
    {
        public static Filename CreateDll(string name) =>
            Filename.Create(name, DllDefinition.Extension);
        public static Filename CreateDll(ReadOnlySpan<char> name) =>
            Filename.Create(name, DllDefinition.Extension);
    }
}
