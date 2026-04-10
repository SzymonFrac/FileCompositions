using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.File.Resource.Specialized.Db.Context;

namespace FileCompositions.Core.File.Resource.Specialized.Db;

public interface IDbFileResource : ISpecializedFileResource
{
    new internal IDbFileResourceContext Context { get; }
    string GetConnectionString();
}
