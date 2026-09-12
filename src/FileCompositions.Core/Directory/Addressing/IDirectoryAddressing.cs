using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Directory.Addressing;

public interface IDirectoryAddressing
{
    Address Address { get; }
}
