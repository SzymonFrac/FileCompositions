using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IStorageBackend StorageBackend { get; }
    
    StorageAddress Address { get; }
}

