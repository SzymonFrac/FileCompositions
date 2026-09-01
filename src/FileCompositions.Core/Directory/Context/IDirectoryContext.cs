using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Session.Source;

namespace FileCompositions.Core.Directory.Context;

internal interface IDirectoryContext
{
    IFileSystemSessionSource SessionSource { get; }

    IFileSystem FileSystem { get; }

    //ValueTask RequestFileSystemAsync(FileSystemRequest.Address request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default);
    //ValueTask<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default);
}
