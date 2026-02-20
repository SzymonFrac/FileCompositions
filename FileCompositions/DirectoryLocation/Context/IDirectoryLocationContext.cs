using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.DirectoryLocation.Context;

internal interface IDirectoryLocationContext
{
    IStorageBackend StorageBackend { get; }
}
