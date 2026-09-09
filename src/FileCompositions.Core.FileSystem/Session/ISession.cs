using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session;

internal partial interface ISession : IDisposable
{
    IFileSystemSource Source { get; }
}
