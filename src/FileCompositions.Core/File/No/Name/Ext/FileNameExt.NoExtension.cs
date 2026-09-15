using FileCompositions.Core.File.No.Extension;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.File.No.Name.Ext;

public static partial class FileNameExt
{
    extension(Filename)
    {
        public static Filename Create(string name) => Filename.Create(name, new NoFileExtension());
        public static Filename Create(ReadOnlySpan<char> name) => Filename.Create(name, new NoFileExtension());
    }
}
