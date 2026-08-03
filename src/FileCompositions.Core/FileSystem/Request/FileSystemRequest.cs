using FileCompositions.Core.FileSystem.Session;

namespace FileCompositions.Core.FileSystem.Request;

internal delegate Task FileSystemRequest(FileSystemSession fileSystemSession, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemRequest<TResult>(FileSystemSession fileSystemSession, CancellationToken cancellationToken = default);
