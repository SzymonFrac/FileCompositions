using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source;

public interface IFileSystemSource
{
    internal Task RequestFileSystemAsync(FileSystemRequest request, CancellationToken cancellationToken = default);
    internal Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken = default);
}
