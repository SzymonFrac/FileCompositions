using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source.Implementations;

// FileSystemSource implementations may do health/logging checks...
internal class FileSystemSource(IFileSystem fileSystem) : IFileSystemSource
{
    private readonly IFileSystem _fileSystem = fileSystem;
    public Task RequestFileSystemAsync(FileSystemRequest request, CancellationToken cancellationToken) =>
        request(_fileSystem, cancellationToken);

    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken) =>
        request(_fileSystem, cancellationToken);
}
