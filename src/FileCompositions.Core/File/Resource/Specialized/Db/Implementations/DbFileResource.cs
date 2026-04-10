using FileCompositions.Core.File.Resource.Specialized.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Db.Context;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Implementations;

internal class DbFileResource(IDbFileResourceContext context, StorageResourceName name) :
    AbstractSpecializedFileResource(context, name), IDbFileResource
{
    new public IDbFileResourceContext Context { get; } = context;

    public string GetConnectionString() => $"DataSource={Context.StorageConnector.GetLocation(Name)}";
}
