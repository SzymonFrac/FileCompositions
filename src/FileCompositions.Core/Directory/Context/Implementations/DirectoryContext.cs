using FileCompositions.Core.Directory.Addressing;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.Directory.Context.Implementations;

internal sealed class DirectoryContext(IFileSystem fileSystem) : IDirectoryContext
{
    public IFileSystem FileSystem { get; } = fileSystem;

    public Task RequestFileSystemAsync(FileSystemRequest.Address request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default) =>
        FileSystem.RequestSessionAsync(request, addressing, cancellationToken);
    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Address<TResult> request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default) =>
        FileSystem.RequestSessionAsync(request, addressing, cancellationToken);
}
