namespace FileCompositions.Core.FileSystem.Proxy.Directory.Request;

internal delegate ValueTask FileSystemDirectoryProxyValueRequest(IFileSystemDirectoryProxy proxy, CancellationToken cancellationToken = default);
internal delegate ValueTask<TResult> FileSystemDirectoryProxyValueRequest<TResult>(IFileSystemDirectoryProxy proxy, CancellationToken cancellationToken = default);
