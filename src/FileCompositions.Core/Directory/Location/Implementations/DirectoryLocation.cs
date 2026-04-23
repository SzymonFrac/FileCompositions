using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Projections.Resources;
using FileCompositions.Core.Directory.ResourceStream;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Query;
using FileCompositions.Core.File.Resource.Query.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.Location.Implementations;

internal class DirectoryLocation(IDirectoryContext context, StorageAddress address) :
    IDirectoryLocation,
    IRequiredDirectoryResourceStream, IOptionalDirectoryResourceStream,
    IResourceDirectory
{
    public IDirectoryContext Context { get; } = context;
    public StorageAddress Address { get; } = address;

    public StorageLocation GetLocation(StorageResourceName name) => Address.With(name);

    public Task<Stream> OpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.OpenReadAsync(Address.With(name), cancellationToken);
    public Task<Stream> OpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.OpenWriteAsync(Address.With(name), cancellationToken);

    public ValueTask<bool> Exists(StorageResourceName name, CancellationToken cancellationToken = default) =>
        Context.StorageBackend.Exists(Address.With(name), cancellationToken);
    public async Task<Stream?> TryOpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        await Exists(name, cancellationToken) ? await OpenReadAsync(name, cancellationToken) : null;
    public async Task<Stream?> TryOpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default) =>
        await Exists(name, cancellationToken) ? await OpenWriteAsync(name, cancellationToken) : null;

    public async ValueTask<TFile?> GetResource<TFile>(StorageResourceName name, CancellationToken cancellationToken)
        where TFile : IFileResource =>
            await Exists(name, cancellationToken)
                ? Context.LocationResolver.Resolve<TFile>(this, name)
                : default;
    public IFileResourceQuery EnumerateResources(CancellationToken cancellationToken = default) =>
        new FileResourceQuery(Context.StorageBackend.EnumerateResourceNames(Address, cancellationToken)
            .Select(n => Context.LocationResolver.Resolve(this, n)));

    public ValueTask CreateResource(StorageResourceName name, CancellationToken cancellationToken) =>
        Context.StorageBackend.CreateResource(Address.With(name), cancellationToken);
    public async ValueTask<bool> TryCreateResource(StorageResourceName name, CancellationToken cancellationToken)
    {
        var exists = await Exists(name, cancellationToken);
        if (exists)
            await CreateResource(name, cancellationToken);
        return exists;
    }
}