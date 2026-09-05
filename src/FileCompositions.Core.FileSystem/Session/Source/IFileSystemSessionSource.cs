using FileCompositions.Core.FileSystem.Session.Request;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default);
}
