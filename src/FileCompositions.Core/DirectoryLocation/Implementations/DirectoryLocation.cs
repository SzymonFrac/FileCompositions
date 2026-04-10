using FileCompositions.Core.DirectoryLocation.Context;
using FileCompositions.Core.DirectoryLocation.Projections.Resources;
using FileCompositions.Core.DirectoryLocation.ResourceStream;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.File.Resource.Specialized.Query;
using FileCompositions.Core.File.Resource.Specialized.Query.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.Implementations;

internal class DirectoryLocation<TOwnership, TNecessity>(IDirectoryLocationContext context, StorageAddress address) :
    IDirectoryLocation,
    IRequiredDirectoryLocationResourceStream, IOptionalDirectoryLocationResourceStream,
    IResourceDirectoryLocation
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public IDirectoryLocationContext Context { get; } = context;
    public StorageAddress Address { get; } = address;


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
        where TFile : ISpecializedFileResource =>
            await Exists(name, cancellationToken)
                ? Context.LocationResolver.Resolve<TFile>(this, name)
                : default;
    public ISpecializedFileResourceQuery EnumerateResources(CancellationToken cancellationToken = default) =>
        new SpecializedFileResourceQuery(Context.StorageBackend.EnumerateResourceNames(Address, cancellationToken)
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