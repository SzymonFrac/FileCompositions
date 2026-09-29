using FileCompositions.Core.File.Specialized.Unspecified.Definition.Implementations;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.Specialized.Unspecified.Name.Ext;

public static partial class FileNameExt
{
    extension(Filename)
    {
        public static Filename CreateUnspecified(string name) =>
            Filename.Create(name, UnspecifiedDefinition.Extension);
        public static Filename CreateUnspecified(ReadOnlySpan<char> name) =>
            Filename.Create(name, UnspecifiedDefinition.Extension);
    }
}
