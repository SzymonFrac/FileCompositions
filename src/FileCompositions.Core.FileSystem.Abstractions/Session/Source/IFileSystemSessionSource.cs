using FileCompositions.Core.FileSystem.Abstractions.Session.Request;

namespace FileCompositions.Core.FileSystem.Abstractions.Session.Source;

public partial interface IFileSystemSessionSource
{
    internal Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default);
    internal Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default);
}
