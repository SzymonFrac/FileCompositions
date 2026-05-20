using FileCompositions.Core.Database.File.Resource.Db.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder.Implementations;

file class DbResourceBuilder<TDbContext> : FileResourceBuilder, IDbResourceBuilder<TDbContext>
    where TDbContext : DbContext
{
    internal DbResourceBuilder(string? name) => Name = name;

    public IDbResourceBuilder<TDbContext> WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDbResource<TDbContext> Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbResource<TDbContext>(context, Name);
        return db;
    }
}

internal class DbResourceBuilder : FileResourceBuilder, IDbResourceBuilder
{
    public IDbResourceBuilder WithName(string name)
    {
        Name = name;
        return this;
    }
    public IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext =>
            new DbResourceBuilder<TNewDbContext>(Name);

    public IDbResource Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbResource(context, Name);
        return db;
    }
}
