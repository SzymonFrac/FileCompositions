using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using static System.IO.FileAccess;
using static System.IO.FileMode;

namespace FileCompositions.Core.Storage.Backend.Implementations;

internal sealed class LocalStorageBackend : IStorageBackend
{
    public Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.OpenRead(location.ToString()));
    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.Create(location.ToString()));
    public Task<Stream> OpenAppendAsync(StorageLocation location, CancellationToken cancellationToken) =>
        Task.FromResult<Stream>(System.IO.File.Open(location.ToString(), Append, Write));
    public Task<Stream> OpenCreateAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.Open(location.ToString(), CreateNew, Write));

    public ValueTask<bool> ExistsAsync(StorageAddress address, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(System.IO.Directory.Exists(address.ToString()));
    public ValueTask<bool> ExistsAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(System.IO.File.Exists(location.ToString()));
    public ValueTask CreateAsync(StorageAddress address, CancellationToken cancellationToken = default)
    {
        System.IO.Directory.CreateDirectory(address.ToString());
        return ValueTask.CompletedTask;
    }
    public ValueTask CreateAsync(StorageLocation location, CancellationToken cancellationToken = default)
    {
        System.IO.File.Create(location.ToString()).Dispose();
        return ValueTask.CompletedTask;
    }
    public ValueTask DeleteAsync(StorageAddress address, CancellationToken cancellationToken)
    {
        System.IO.Directory.Delete(address.ToString());
        return ValueTask.CompletedTask;
    }
    public ValueTask DeleteAsync(StorageLocation location, CancellationToken cancellationToken)
    {
        System.IO.File.Delete(location.ToString());
        return ValueTask.CompletedTask;
    }
}
