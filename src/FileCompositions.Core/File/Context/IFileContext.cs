using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Request;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    //IFileSystemSource FileSystemSource { get; }
    Task RequestFileSystemAsync(FileSystemRequest request, FileSystemLocation location, CancellationToken cancellationToken = default);
    Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, FileSystemLocation location, CancellationToken cancellationToken = default);

    FileSystemAddress Address { get; }
}

