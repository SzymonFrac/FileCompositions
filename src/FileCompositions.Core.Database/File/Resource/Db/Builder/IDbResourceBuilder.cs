using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder;

public interface IDbResourceBuilder<TDbContext> : IFileResourceBuilder
    where TDbContext : DbContext
{
    IDbResourceBuilder<TDbContext> WithName(string name);

    internal IDbResource<TDbContext> Build(in IFileContext context);
}

public interface IDbResourceBuilder : IFileResourceBuilder
{
    IDbResourceBuilder WithName(string name);
    IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext;

    internal IDbResource Build(in IFileContext context);
}
