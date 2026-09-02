using FileCompositions.Core.FileSystem.Proxy.Directory.Request;

namespace FileCompositions.Core.FileSystem.Proxy.Directory.Source;

internal interface IFileSystemDirectoryProxySource
{
    Task RequestAsync(FileSystemDirectoryProxyRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemDirectoryProxyRequest<TResult> request, CancellationToken cancellationToken = default);
}
