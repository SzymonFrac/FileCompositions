using FileCompositions.Core.FileSystem.Proxy.File.Request;

namespace FileCompositions.Core.FileSystem.Proxy.File.Source;

internal interface IFileSystemFileProxySource
{
    Task RequestAsync(FileSystemFileProxyRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemFileProxyRequest<TResult> request, CancellationToken cancellationToken = default);
    ValueTask RequestAsync(FileSystemFileProxyValueRequest request, CancellationToken cancellationToken = default);
    ValueTask<TResult> RequestAsync<TResult>(FileSystemFileProxyValueRequest<TResult> request, CancellationToken cancellationToken = default);
}
