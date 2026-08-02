using FileCompositions.Core.FileSystem;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IFileSystem FileSystem { get; }
}
