using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Query;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location.Extensions;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.Directory.Location.Abstract;

internal abstract class DirectoryLocation(IDirectoryContext context, StorageAddress address) :
    IDirectoryLocation//, IResourceDirectory
{
    public IDirectoryContext Context { get; } = context;
    public StorageAddress Address { get; } = address;

    IStorageBackend IDirectoryInterface<RequiredDefinition>.StorageBackend => Context.StorageBackend;



    // Ignore file resolver untill I get to it \_ㇱ_/
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