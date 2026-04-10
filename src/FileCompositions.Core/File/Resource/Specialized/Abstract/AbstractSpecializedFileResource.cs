using FileCompositions.Core.File.Resource.Specialized.Context;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Specialized.Abstract;

internal class AbstractSpecializedFileResource(ISpecializedFileResourceContext context, StorageResourceName name) : ISpecializedFileResource
{
    public ISpecializedFileResourceContext Context { get; } = context;
    public StorageResourceName Name { get; } = name;

    public Task<Stream> OpenReadAsync() =>
        Context.StorageConnector.OpenReadAsync(Name);
    public Task<Stream> OpenWriteAsync() =>
        Context.StorageConnector.OpenWriteAsync(Name);

    string IFileResource.Name => Name.Value;
}
