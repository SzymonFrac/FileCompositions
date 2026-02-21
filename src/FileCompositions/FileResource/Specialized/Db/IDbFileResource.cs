using FileCompositions.Core.FileResource.Specialized.Db.Context;

namespace FileCompositions.Core.FileResource.Specialized.Db;

public interface IDbFileResource : ISpecializedFileResource
{
    new internal IDbFileResourceContext Context { get; }
    string GetConnectionString();
}
