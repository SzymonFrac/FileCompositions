using FileCompositions.Core.File.Name;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Name.Ext;

public static partial class FileNameExt
{
    extension(FileName)
    {
        public static FileName CreateDll(string name) =>
            FileName.Create(name, DllDefinition.Extension);
        public static FileName CreateDll(ReadOnlySpan<char> name) =>
            FileName.Create(name, DllDefinition.Extension);
    }
}
