using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.FileSystem.Location.Implementations;

public sealed record LocalFileSystemLocation(FileSystemAddress Address, FileName Name) : FileSystemLocation(Address, Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
