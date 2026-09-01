namespace FileCompositions.Core.FileSystem.Proxy.File.Request;

internal delegate ValueTask FileSystemFileProxyValueRequest(IFileSystemFileProxy proxy, CancellationToken cancellationToken = default);
internal delegate ValueTask<TResult> FileSystemFileProxyValueRequest<TResult>(IFileSystemFileProxy proxy, CancellationToken cancellationToken = default);
