using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.File.Addressing.Ext;

public static partial class FileAddressingExt
{
    extension(IFileAddressing file)
    {
        public FileSystemLocation RequestLocation() => file.RequestAddress().With(file.Name);
    }
}
