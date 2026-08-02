using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    IFileSystemSource FileSystemSource { get; }

    FileSystemAddress Address { get; }
}

