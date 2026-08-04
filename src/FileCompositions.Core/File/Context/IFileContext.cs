using FileCompositions.Core.File.Addressing;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.File.Context;

internal interface IFileContext
{
    FileSystemAddress Address { get; }

    Task RequestFileSystemAsync(FileSystemRequest.Location request, IFileAddressing addressing, CancellationToken cancellationToken = default);
    Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Location<TResult> request, IFileAddressing addressing, CancellationToken cancellationToken = default);
}

