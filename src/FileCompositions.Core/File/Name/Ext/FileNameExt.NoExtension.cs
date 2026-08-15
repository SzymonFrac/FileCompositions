using FileCompositions.Core.File.Extension.None;

namespace FileCompositions.Core.File.Name.Ext;

public static partial class FileNameExt
{
    extension(FileName)
    {
        public static FileName Create(string name) => FileName.Create(name, new NoFileExtension());
        public static FileName Create(ReadOnlySpan<char> name) => FileName.Create(name, new NoFileExtension());
    }
}
