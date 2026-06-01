using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal sealed class DirectoryContext(IStorageBackend storageBackend) : IDirectoryContext
{
    public IStorageBackend StorageBackend { get; } = storageBackend;
}
