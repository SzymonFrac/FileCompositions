using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.ResourceName;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FileCompositions.Extensions")]
namespace FileCompositions.Core.Storage.Backend.Implementations;

internal class LocalDiskStorageBackend : IStorageBackend
{
    public Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.OpenRead(location.ToString()));
    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(System.IO.File.OpenWrite(location.ToString()));
    public ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(System.IO.File.Exists(location.ToString()));
    public ValueTask CreateAddress(StorageAddress address, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(address.ToString());
        return ValueTask.CompletedTask;
    }
    public ValueTask CreateResource(StorageLocation location, CancellationToken cancellationToken = default)
    {
        System.IO.File.Create(location.ToString());
        return ValueTask.CompletedTask;
    }

    public IAsyncEnumerable<StorageResourceName> EnumerateResourceNames(StorageAddress address, CancellationToken cancellationToken = default) =>
        Directory.EnumerateFiles(address.ToString())
            .Select(StorageResourceName.GetFromPath)
            .ToAsyncEnumerable();
}
