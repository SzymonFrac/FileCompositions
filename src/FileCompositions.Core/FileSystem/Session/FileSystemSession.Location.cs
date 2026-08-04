using FileCompositions.Core.FileSystem.Location;

namespace FileCompositions.Core.FileSystem.Session;

internal static partial class FileSystemSession
{
    public abstract class LocationSession : IDisposable
    {
        private bool disposed = false;

        private readonly FileSystemLocation _location;
        private readonly IFileSystem _fileSystem;

        public LocationSession(FileSystemLocation location, IFileSystem fileSystem) => (_location, _fileSystem) = (location, fileSystem);


        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.OpenReadAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.OpenWriteAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.OpenAppendAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.OpenCreateAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));

        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.ExistsAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public ValueTask<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.ExistsAsync(_location.Address, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.CreateAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));
        public ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
            !disposed
                ? _fileSystem.DeleteAsync(_location, cancellationToken)
                : throw new ObjectDisposedException(nameof(LocationSession));


        public void Dispose() => disposed = true;
    }
}
