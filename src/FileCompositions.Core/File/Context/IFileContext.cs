using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.File.Context;

public interface IFileContext
{
    internal IStorageBackend StorageBackend { get; }
    
    internal StorageAddress Address { get; }
}

