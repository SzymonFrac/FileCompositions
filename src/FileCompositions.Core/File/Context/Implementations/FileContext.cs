using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.File.Context.Implementations;

internal class FileContext(IStorageBackend storageBackend, StorageAddress address) : IFileContext
{
    public IStorageBackend StorageBackend { get; } = storageBackend;
    public StorageAddress Address { get; } = address;
}
