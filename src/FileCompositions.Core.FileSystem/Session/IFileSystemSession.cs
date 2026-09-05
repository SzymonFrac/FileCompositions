using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session;

internal partial interface IFileSystemSession : IDisposable
{
    IFileSystemSource Source { get; }
}
