namespace FileCompositions.Core.FileSystem.Proxy.File.Request;

internal delegate Task FileProxyRequest(IFileProxy proxy, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileProxyRequest<TResult>(IFileProxy proxy, CancellationToken cancellationToken = default);
