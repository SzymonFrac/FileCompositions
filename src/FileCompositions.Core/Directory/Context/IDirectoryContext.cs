using FileCompositions.Core.Directory.Addressing;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IFileSystem FileSystem { get; }

    ValueTask RequestFileSystemAsync(FileSystemRequest.Address request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default);
    ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default);
}
