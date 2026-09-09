namespace FileCompositions.Core.FileSystem.Proxy.Directory.Request;

internal delegate Task DirectoryProxyRequest(IDirectoryProxy proxy, CancellationToken cancellationToken = default);
internal delegate Task<TResult> DirectoryProxyRequest<TResult>(IDirectoryProxy proxy, CancellationToken cancellationToken = default);
