using FileCompositions.Core.Database.File.Resource.Db.Context;
using FileCompositions.Core.Database.File.Resource.Db.Interface;
using FileCompositions.Core.File.Resource;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db;

public interface IDbResource<TDbContext> : IDbResource
    where TDbContext : DbContext;

public interface IDbResource : IFileResource, IDbResourceInterface
{
    new internal IDbResourceContext Context { get; }    
}
