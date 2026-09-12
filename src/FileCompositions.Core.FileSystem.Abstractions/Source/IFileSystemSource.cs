using FileCompositions.Core.FileSystem.Abstractions.Request;

namespace FileCompositions.Core.FileSystem.Abstractions.Source;

internal interface IFileSystemSource
{
    Task RequestAsync(FileSystemRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(FileSystemRequest<TResult> request, CancellationToken cancellationToken = default);
}
