using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystem storageBackend, FileSystemAddress address) : IFileContext
{
    public IFileSystem StorageBackend { get; } = storageBackend;
    public FileSystemAddress Address { get; } = address;
}
