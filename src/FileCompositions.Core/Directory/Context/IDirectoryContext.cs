using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IStorageBackend StorageBackend { get; }
}
