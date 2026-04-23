using FileCompositions.Core.File.Resource.Context;
using FileCompositions.Core.Storage.Location;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Abstract;

internal class AbstractFileResource(IFileResourceContext context, StorageResourceName name) : IFileResource
{
    public IFileResourceContext Context { get; } = context;
    public StorageResourceName Name { get; } = name;

    public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
        Context.StorageConnector.OpenReadAsync(Name, cancellationToken);
    public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
        Context.StorageConnector.OpenWriteAsync(Name, cancellationToken);
    public StorageLocation GetFullLocation() =>
        Context.StorageConnector.GetLocation(Name);
}
