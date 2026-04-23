using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource.Builder;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder;

public interface IDbResourceBuilder<TDbContext> : IDbResourceBuilder
    where TDbContext : DbContext
{
    new IDbResourceBuilder<TDbContext> WithName(string name);

    new internal IDbResource<TDbContext> Build(IDirectoryLocation directory);
}

public interface IDbResourceBuilder : IFileResourceBuilder
{
    new IDbResourceBuilder WithName(string name);
    IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext;

    internal IDbResource Build(IDirectoryLocation directory);
}
