using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.File.Context.Implementations;

internal class FileContext(IDirectoryLocation directoryLocation) : IFileContext
{
    public IStorageBackend StorageBackend { get; } = directoryLocation.Context.StorageBackend;
    public StorageAddress Address { get; } = directoryLocation.Address;
}
