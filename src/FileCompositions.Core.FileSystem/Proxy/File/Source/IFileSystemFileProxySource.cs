using FileCompositions.Core.FileSystem.Proxy.File.Request;

namespace FileCompositions.Core.FileSystem.Proxy.File.Source;

internal interface IFileSystemFileProxySource
{
    Task RequestAsync(FileSystemFileProxyRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemFileProxyRequest<TResult> request, CancellationToken cancellationToken = default);
}
