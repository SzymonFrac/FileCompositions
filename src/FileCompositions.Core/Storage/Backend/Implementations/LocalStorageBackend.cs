using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.Storage.Backend.Implementations;

internal class LocalStorageBackend : IStorageBackend
{
    public Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.OpenRead(location.ToString()));
    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.OpenWrite(location.ToString()));
    public ValueTask<bool> Exists(StorageAddress address, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(System.IO.Directory.Exists(address.ToString()));
    public ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(System.IO.File.Exists(location.ToString()));
    public ValueTask Create(StorageAddress address, CancellationToken cancellationToken = default)
    {
        System.IO.Directory.CreateDirectory(address.ToString());
        return ValueTask.CompletedTask;
    }
    public ValueTask Create(StorageLocation location, CancellationToken cancellationToken = default)
    {
        System.IO.File.Create(location.ToString());
        return ValueTask.CompletedTask;
    }

    public IAsyncEnumerable<StorageResourceName> EnumerateResources(StorageAddress address, CancellationToken cancellationToken = default) =>
        System.IO.Directory.EnumerateFiles(address.ToString())
            .Select(StorageResourceName.GetFromPath)
            .ToAsyncEnumerable();
}
