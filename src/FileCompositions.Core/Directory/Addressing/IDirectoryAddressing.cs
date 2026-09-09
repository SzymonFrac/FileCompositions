using FileCompositions.Core.FileSystem.Addressing;

namespace FileCompositions.Core.Directory.Addressing;

public interface IDirectoryAddressing
{
    Address Address { get; }
}
