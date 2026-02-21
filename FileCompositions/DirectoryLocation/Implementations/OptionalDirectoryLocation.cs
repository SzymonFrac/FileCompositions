using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.Implementations;

internal class OptionalDirectoryLocation(IDirectoryLocationContext context, StorageAddress address) : IDirectoryLocation
{
    public IDirectoryLocationContext Context { get; } = context;
    public StorageAddress Address { get; } = address;

    public StorageLocation GetLocation(StorageResourceName name) => Address.With(name);
    public Task<Stream> OpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.OpenReadAsync(Address.With(name), cancellationToken);
    public Task<Stream> OpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.OpenWriteAsync(Address.With(name), cancellationToken);
    public ValueTask<bool> Exists(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.Exists(Address.With(name), cancellationToken);
}
