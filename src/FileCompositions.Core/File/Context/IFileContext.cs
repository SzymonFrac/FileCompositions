using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IFileSystem StorageBackend { get; }
    
    FileSystemAddress Address { get; }
}

