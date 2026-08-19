using FileCompositions.Core.File.Addressing;
using FileCompositions.Core.File.Addressing.Ext;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Location;
using FileCompositions.Core.FileSystem.Request;
using static FileCompositions.Core.FileSystem.IFileSystem;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed Task RequestSessionAsync(FileSystemRequest.Location request, IFileAddressing addressing, CancellationToken cancellationToken = default)
    {
        using var session = new Session(addressing, this);
        return request(session, cancellationToken);
    }

    internal sealed Task<TResult> RequestSessionAsync<TResult>(FileSystemRequest.Location<TResult> request, IFileAddressing addressing, CancellationToken cancellationToken = default)
    {
        using var session = new Session(addressing, this);
        return request(session, cancellationToken);
    }

    internal abstract class LocationSession
    {
        private FileSystemLocation Location => field ??= Addressing.RequestLocation();
        private FileSystemAddress Address => field ??= Addressing.RequestAddress();

        protected IFileAddressing Addressing { get; }
        protected IFileSystem FileSystem { get; }

        protected LocationSession(IFileAddressing addressing, IFileSystem fileSystem) => (Addressing, FileSystem) = (addressing, fileSystem);


        public virtual Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) => FileSystem.OpenReadAsync(Location, cancellationToken);
        public virtual Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) => FileSystem.OpenWriteAsync(Location, cancellationToken);
        public virtual Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) => FileSystem.OpenAppendAsync(Location, cancellationToken);
        public virtual Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) => FileSystem.OpenCreateAsync(Location, cancellationToken);

        public virtual ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) => FileSystem.ExistsAsync(Location, cancellationToken);
        public virtual ValueTask<bool> AddressExistsAsync(CancellationToken cancellationToken = default) => FileSystem.ExistsAsync(Address, cancellationToken);
        public virtual ValueTask CreateAsync(CancellationToken cancellationToken = default) => FileSystem.CreateAsync(Location, cancellationToken);
        public virtual ValueTask DeleteAsync(CancellationToken cancellationToken = default) => FileSystem.DeleteAsync(Location, cancellationToken);
    }
}

file sealed class Session(IFileAddressing addressing, IFileSystem fileSystem) : LocationSession(addressing, fileSystem), IDisposable
{
    private bool disposed = false;

    public override Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.OpenReadAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.OpenWriteAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.OpenAppendAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.OpenCreateAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));

    public override ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.ExistsAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override ValueTask<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.AddressExistsAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.CreateAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));
    public override ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.DeleteAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(LocationSession));


    public void Dispose() => disposed = true;
}
