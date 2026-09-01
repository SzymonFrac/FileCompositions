namespace FileCompositions.Core.FileSystem.Request;

internal delegate ValueTask FileSystemValueRequest(in IFileSystem fileSystem, CancellationToken cancellationToken = default);
internal delegate ValueTask<TResult> FileSystemValueRequest<TResult>(in IFileSystem fileSystem, CancellationToken cancellationToken = default);
