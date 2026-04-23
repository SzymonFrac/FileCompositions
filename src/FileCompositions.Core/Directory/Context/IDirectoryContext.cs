using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IStorageBackend StorageBackend { get; }
    IFileLocationResolver LocationResolver { get; }
}
