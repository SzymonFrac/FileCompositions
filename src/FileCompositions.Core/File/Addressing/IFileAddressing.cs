using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.File.Addressing;

public interface IFileAddressing
{
    FileSystemResourceName Name { get; }

    FileSystemAddress RequestAddress();
}
