namespace FileCompositions.Core.FileSystem.Proxy.File.Request;

internal delegate Task FileSystemFileProxyRequest(IFileSystemFileProxy proxy, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemFileProxyRequest<TResult>(IFileSystemFileProxy proxy, CancellationToken cancellationToken = default);
