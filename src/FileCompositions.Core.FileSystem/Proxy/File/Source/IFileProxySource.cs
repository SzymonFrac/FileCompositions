using FileCompositions.Core.FileSystem.Proxy.File.Request;

namespace FileCompositions.Core.FileSystem.Proxy.File.Source;

internal interface IFileProxySource
{
    Task RequestAsync(FileProxyRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileProxyRequest<TResult> request, CancellationToken cancellationToken = default);
}
