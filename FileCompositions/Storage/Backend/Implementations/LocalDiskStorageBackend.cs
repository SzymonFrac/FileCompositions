using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FileCompositions.Extensions")]
namespace FileCompositions.Core.Storage.Backend.Implementations;

internal class LocalDiskStorageBackend : IStorageBackend
{
    public Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(File.OpenRead(location.ToString()));
    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(File.OpenWrite(location.ToString()));
    public ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default) =>
        ValueTask.FromResult(File.Exists(location.ToString()));
    public ValueTask CreateAddress(StorageAddress address, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(address.ToString());
        return ValueTask.CompletedTask;
    }
}
