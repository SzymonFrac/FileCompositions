using FileCompositions.Core.Database.File.Resource.Db.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder.Implementations;

internal class DbResourceBuilder<TDbContext>(string? name)
    : FileResourceBuilder<IDbResource<TDbContext>, IDbResourceBuilder<TDbContext>>, IDbResourceBuilder<TDbContext>
    where TDbContext : DbContext
{
    private string? name = name;

    public override IDbResourceBuilder<TDbContext> WithName(string n)
    {
        name = n;
        return this;
    }

    public override IDbResource<TDbContext> Build(in IFileContext context)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new StandardDbResource<TDbContext>(context, name);
        return db;
    }
}

internal class DbResourceBuilder : FileResourceBuilder<IDbResource, IDbResourceBuilder>, IDbResourceBuilder
{
    private string? name;

    public override IDbResourceBuilder WithName(string n)
    {
        name = n;
        return this;
    }
    public IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext =>
            new DbResourceBuilder<TNewDbContext>(name);

    public override IDbResource Build(in IFileContext context)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new StandardDbResource(context, name);
        return db;
    }
}
