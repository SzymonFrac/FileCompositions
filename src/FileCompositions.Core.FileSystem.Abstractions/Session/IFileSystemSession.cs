using FileCompositions.Core.FileSystem.Abstractions.Source;

namespace FileCompositions.Core.FileSystem.Abstractions.Session;

internal partial interface IFileSystemSession : IDisposable
{
    IFileSystemSource Source { get; }
}
