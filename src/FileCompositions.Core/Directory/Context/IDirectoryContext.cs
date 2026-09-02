using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Session.Source;
using System.Globalization;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IFileSystemSessionSource SessionSource { get; }

    IFileSystem FileSystem { get; }
}
