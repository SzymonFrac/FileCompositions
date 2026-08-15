using FileCompositions.Core.File.Name;
using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.File.Addressing;

public interface IFileAddressing
{
    FileName Name { get; }

    FileSystemAddress RequestAddress();
}