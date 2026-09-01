using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.FileSystem.Source;

internal interface IFileSystemSource : IDisposable
{
    Task RequestAsync(FileSystemRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken = default);
    ValueTask RequestAsync(FileSystemValueRequest request, CancellationToken cancellationToken = default);
    ValueTask<TResult> RequestAsync<TResult>(FileSystemValueRequest<TResult> request, CancellationToken cancellationToken = default);
}
