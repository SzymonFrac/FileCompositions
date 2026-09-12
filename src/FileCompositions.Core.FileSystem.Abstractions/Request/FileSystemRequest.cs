namespace FileCompositions.Core.FileSystem.Abstractions.Request;

internal delegate Task FileSystemRequest(in IFileSystem fileSystem, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemRequest<TResult>(in IFileSystem fileSystem, CancellationToken cancellationToken = default);
