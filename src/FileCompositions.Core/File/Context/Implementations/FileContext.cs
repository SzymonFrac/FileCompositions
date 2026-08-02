using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystemSource fileSystemRequestable, FileSystemAddress address) : IFileContext
{
    public IFileSystemSource FileSystemSource { get; } = fileSystemRequestable;
    public FileSystemAddress Address { get; } = address;
}
