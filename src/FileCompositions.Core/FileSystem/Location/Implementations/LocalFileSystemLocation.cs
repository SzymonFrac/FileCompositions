using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.FileSystem.Location.Implementations;

public sealed record LocalFileSystemLocation(FileSystemAddress Address, FileSystemResourceName Name) : FileSystemLocation(Address, Name)
{
    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
