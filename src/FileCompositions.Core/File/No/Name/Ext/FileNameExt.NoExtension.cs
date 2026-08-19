using FileCompositions.Core.File.Name;
using FileCompositions.Core.File.No.Extension;

namespace FileCompositions.Core.File.No.Name.Ext;

public static partial class FileNameExt
{
    extension(FileName)
    {
        public static FileName Create(string name) => FileName.Create(name, new NoFileExtension());
        public static FileName Create(ReadOnlySpan<char> name) => FileName.Create(name, new NoFileExtension());
    }
}
