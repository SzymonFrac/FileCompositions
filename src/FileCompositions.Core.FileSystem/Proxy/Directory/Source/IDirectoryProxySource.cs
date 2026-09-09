using FileCompositions.Core.FileSystem.Proxy.Directory.Request;

namespace FileCompositions.Core.FileSystem.Proxy.Directory.Source;

internal interface IDirectoryProxySource
{
    Task RequestAsync(DirectoryProxyRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(DirectoryProxyRequest<TResult> request, CancellationToken cancellationToken = default);
}
