using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source;

internal interface IFileSystemSource
{
    Task RequestAsync(FileSystemRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken = default);
}
