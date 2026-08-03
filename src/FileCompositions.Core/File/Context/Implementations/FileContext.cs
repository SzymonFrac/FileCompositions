using FileCompositions.Core.FileSystem;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Ext;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Request;

namespace FileCompositions.Core.File.Context.Implementations;

internal sealed class FileContext(IFileSystem fileSystem, FileSystemAddress address) : IFileContext
{
    private readonly IFileSystem _fileSystem = fileSystem;
    public FileSystemAddress Address { get; } = address;

    public Task RequestFileSystemAsync(FileSystemRequest request, FileSystemLocation location, CancellationToken cancellationToken = default) =>
        _fileSystem.RequestSessionAsync(request, location, cancellationToken);

    public Task<TResult> RequestFileSystemAsync<TResult>(FileSystemRequest<TResult> request, FileSystemLocation location, CancellationToken cancellationToken = default) =>
        _fileSystem.RequestSessionAsync(request, location, cancellationToken);
}
