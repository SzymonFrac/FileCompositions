using FileCompositions.Core.Storage.Backend.Container;

namespace FileCompositions.Core.Storage.Backend.Provider.Implementations;

internal class StorageBackendProvider<TStorageBackend> : IStorageBackendProvider
    where TStorageBackend : class, IStorageBackend
{
    public IStorageBackend GetStorageBackend(in IStorageBackendContainer container) =>
        container.GetStorageBackend<TStorageBackend>();
}
