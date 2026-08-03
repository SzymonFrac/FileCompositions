using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.FileSystem.Session;

public sealed class FileSystemSession : IDisposable
{
    private bool disposed = false;

    private readonly FileSystemLocation _location;
    private readonly IFileSystem _fileSystem;

    internal FileSystemSession(FileSystemLocation location, IFileSystem fileSystem) => (_location, _fileSystem) = (location, fileSystem);


    public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.OpenReadAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.OpenWriteAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.OpenAppendAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.OpenCreateAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));

    public ValueTask<bool> ExistsAddressAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.ExistsAsync(_location.Address, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public ValueTask<bool> ExistsLocationAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.ExistsAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public ValueTask CreateAddressAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.CreateAsync(_location.Address, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public ValueTask CreateLocationAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.CreateAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public ValueTask DeleteAddressAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.DeleteAsync(_location.Address, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));
    public ValueTask DeleteLocationAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? _fileSystem.DeleteAsync(_location, cancellationToken)
            : throw new ObjectDisposedException(nameof(FileSystemSession));


    public void Dispose() => disposed = true;
}
