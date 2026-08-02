namespace FileCompositions.Core.FileSystem.Request;

internal delegate Task FileSystemRequest(IFileSystem fileSystem, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemRequest<TResult>(IFileSystem fileSystem, CancellationToken cancellationToken = default);
