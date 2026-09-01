using FileCompositions.Core.Directory.Addressing;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.FileSystem.Request;
using static FileCompositions.Core.FileSystem.IFileSystem;

namespace FileCompositions.Core.FileSystem;

public partial interface IFileSystem
{
    internal sealed Task RequestSessionAsync(FileSystemRequest.Address request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default)
    {
        using var session = new Session(addressing, this);
        return request(session, cancellationToken);
    }

    internal sealed Task<TResult> RequestSessionAsync<TResult>(FileSystemRequest.Address<TResult> request, IDirectoryAddressing addressing, CancellationToken cancellationToken = default)
    {
        using var session = new Session(addressing, this);
        return request(session, cancellationToken);
    }


    internal abstract class AddressSession
    {
        private FileSystemAddress Address => field ??= Addressing.Address;

        protected IDirectoryAddressing Addressing { get; }
        private IFileSystem FileSystem { get; }

        protected AddressSession(IDirectoryAddressing addressing, IFileSystem fileSystem) => (Addressing, FileSystem) = (addressing, fileSystem);


        public virtual Task<bool> ExistsAsync(CancellationToken cancellationToken = default) => FileSystem.ExistsAsync(Address, cancellationToken);
        public virtual Task CreateAsync(CancellationToken cancellationToken = default) => FileSystem.CreateAsync(Address, cancellationToken);
        public virtual Task DeleteAsync(CancellationToken cancellationToken = default) => FileSystem.DeleteAsync(Address, cancellationToken);
    }
}

file sealed class Session(IDirectoryAddressing addressing, IFileSystem fileSystem) : AddressSession(addressing, fileSystem), IDisposable
{
    private bool disposed = false;

    public override Task<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.ExistsAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(AddressSession));
    public override Task CreateAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.CreateAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(AddressSession));
    public override Task DeleteAsync(CancellationToken cancellationToken = default) =>
        !disposed
            ? base.DeleteAsync(cancellationToken)
            : throw new ObjectDisposedException(nameof(AddressSession));

    public void Dispose() => disposed = true;
}