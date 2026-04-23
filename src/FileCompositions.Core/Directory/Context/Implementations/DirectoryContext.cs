using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal class DirectoryContext(IStorageBackend storageBackend, IFileLocationResolver locationResolver) : IDirectoryContext
{
    public IStorageBackend StorageBackend { get; } = storageBackend;
    public IFileLocationResolver LocationResolver { get; } = locationResolver;
}
