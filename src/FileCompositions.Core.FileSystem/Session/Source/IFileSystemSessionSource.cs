using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface IFileSystemSessionSource
{
    //Task RequestAsync(FileSystemSessionRequest request, CancellationToken cancellationToken = default);
    //Task<TResult> RequestAsync<TResult>(FileSystemSessionRequest<TResult> request, CancellationToken cancellationToken = default);
    //ValueTask RequestAsync(FileSystemSessionValueRequest request, CancellationToken cancellationToken = default);
    //ValueTask<TResult> RequestAsync<TResult>(FileSystemSessionValueRequest<TResult> request, CancellationToken cancellationToken = default);

    //ValueTask RequestAsync(FileSystemSessionValueRequest request, CancellationToken cancellationToken = default);
    //ValueTask<TResult> RequestAsync<TResult>(FileSystemSessionValueRequest<TResult> request, CancellationToken cancellationToken = default);

    //FileSystemSession RequestSession();
    IFileSystemSource RequestSource();
}
