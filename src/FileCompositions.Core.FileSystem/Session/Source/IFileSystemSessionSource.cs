using FileCompositions.Core.FileSystem.Session.Request;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    //Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default);
    //Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default);
    //ValueTask RequestAsync(FileSystemSessionValueRequest request, CancellationToken cancellationToken = default);
    //ValueTask<TResult> RequestAsync<TResult>(FileSystemSessionValueRequest<TResult> request, CancellationToken cancellationToken = default);

    //ValueTask RequestAsync(FileSystemSessionValueRequest request, CancellationToken cancellationToken = default);
    //ValueTask<TResult> RequestAsync<TResult>(FileSystemSessionValueRequest<TResult> request, CancellationToken cancellationToken = default);
    Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default);

    //IFileSystemSource RequestSource();
}
