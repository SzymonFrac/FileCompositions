using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Abstractions.Session.Source;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IFileSystemSessionSource SessionSource { get; }

    IFileSystem FileSystem { get; }
}
