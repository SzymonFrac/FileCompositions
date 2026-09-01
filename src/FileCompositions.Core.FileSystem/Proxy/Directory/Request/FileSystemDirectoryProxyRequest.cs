namespace FileCompositions.Core.FileSystem.Proxy.Directory.Request;

internal delegate Task FileSystemDirectoryProxyRequest(IFileSystemDirectoryProxy proxy, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemDirectoryProxyRequest<TResult>(IFileSystemDirectoryProxy proxy, CancellationToken cancellationToken = default);
