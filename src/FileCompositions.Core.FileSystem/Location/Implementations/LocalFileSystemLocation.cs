using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Name;

namespace FileCompositions.Core.FileSystem.Location.Implementations;

public sealed record LocalFileSystemLocation(FileSystemAddress Address, FileSystemFilename Name) : FileSystemLocation(Address, Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
