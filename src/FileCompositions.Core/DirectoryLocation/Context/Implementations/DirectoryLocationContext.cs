using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.DirectoryLocation.Context.Implementations;

internal class DirectoryLocationContext(IStorageBackend storageBackend, IFileLocationResolver locationResolver) : IDirectoryLocationContext
{
    public IStorageBackend StorageBackend { get; } = storageBackend;
    public IFileLocationResolver LocationResolver { get; } = locationResolver;
}
