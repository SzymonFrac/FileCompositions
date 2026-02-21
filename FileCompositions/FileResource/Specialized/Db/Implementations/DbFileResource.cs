using FileCompositions.Core.FileResource.Specialized.Abstract;
using FileCompositions.Core.FileResource.Specialized.Db.Context;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.FileResource.Specialized.Db.Implementations;

internal class DbFileResource(IDbFileResourceContext context, StorageResourceName name) :
    AbstractSpecializedFileResource(context, name), IDbFileResource
{
    new public IDbFileResourceContext Context { get; } = context;

    public string GetConnectionString() => $"DataSource={Context.StorageConnector.GetLocation(Name)}";
}
