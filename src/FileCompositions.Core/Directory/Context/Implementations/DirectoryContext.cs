using FileCompositions.Core.FileSystem;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal sealed class DirectoryContext(IFileSystem storageBackend) : IDirectoryContext
{
    public IFileSystem StorageBackend { get; } = storageBackend;
}
