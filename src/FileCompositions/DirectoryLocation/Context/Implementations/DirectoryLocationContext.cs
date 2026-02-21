using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.DirectoryLocation.Context.Implementations;

internal class DirectoryLocationContext(IStorageBackend storageBackend) : IDirectoryLocationContext
{
    public IStorageBackend StorageBackend { get; } = storageBackend;
}
