using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.Directory.Addressing;

public interface IDirectoryAddressing
{
    FileSystemAddress Address { get; }
}
