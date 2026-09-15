namespace FileCompositions.Core.FileSystem.Abstractions.Session.Request;

internal delegate Task FileSystemSessionRequest(IFileSystemSession session, CancellationToken cancellationToken = default);
internal delegate Task<TResult> FileSystemSessionRequest<TResult>(IFileSystemSession session, CancellationToken cancellationToken = default);
