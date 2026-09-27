using FileCompositions.Core.FileSystem.Addressing.Abstractions;

namespace FileCompositions.Core.Directory.Addressing;

public interface IDirectoryAddressing
{
    Address Address { get; }
}
