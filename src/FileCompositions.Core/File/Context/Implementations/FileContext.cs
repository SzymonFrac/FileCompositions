using FileCompositions.Core.File.Addressing;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystem fileSystem, FileSystemAddress address) : IFileContext
{
    private readonly IFileSystem _fileSystem = fileSystem;
    public FileSystemAddress Address { get; } = address;

    public Task RequestFileSystemAsync(FileSystemRequest.Location request, IFileAddressing addressing, CancellationToken cancellationToken = default) =>
        _fileSystem.RequestSessionAsync(request, addressing, cancellationToken);
    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest.Location<TResult> request, IFileAddressing addressing, CancellationToken cancellationToken = default) =>
        _fileSystem.RequestSessionAsync(request, addressing, cancellationToken);
}
