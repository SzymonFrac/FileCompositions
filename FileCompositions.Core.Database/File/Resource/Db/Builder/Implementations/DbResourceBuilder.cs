using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.Database.File.Resource.Db.Context.Implementations;
using FileCompositions.Core.Database.File.Resource.Db.Implementations;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.Storage.ResourceName;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder.Implementations;

internal class DbResourceBuilder<TDbContext>(string? name) : IDbResourceBuilder<TDbContext>
        where TDbContext : DbContext
{
    private string? name = name;

    public IDbResourceBuilder<TDbContext> WithName(string n)
    {
        name = n;
        return this;
    }
    public IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext =>
            new DbResourceBuilder<TNewDbContext>(name);

    public IDbResource<TDbContext> Build(IDirectoryLocation directory)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var resourceName = StorageResourceName.CreateDb(name);
        var context = new DbResourceContext(directory);

        var db = new DbResource<TDbContext>(context, resourceName);
        return db;
    }

    IFileResourceBuilder IFileResourceBuilder.WithName(string name) => WithName(name);
    IDbResourceBuilder IDbResourceBuilder.WithName(string name) => WithName(name);
    IDbResource IDbResourceBuilder.Build(IDirectoryLocation directory) => Build(directory);
}

internal class DbResourceBuilder : IDbResourceBuilder
{
    private string? name;

    public IDbResourceBuilder WithName(string n)
    {
        name = n;
        return this;
    }
    public IDbResourceBuilder<TNewDbContext> AddDbContext<TNewDbContext>()
        where TNewDbContext : DbContext =>
            new DbResourceBuilder<TNewDbContext>(name);

    public IDbResource Build(IDirectoryLocation directory)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var resourceName = StorageResourceName.CreateDb(name);
        var context = new DbResourceContext(directory);

        var db = new DbResource(context, resourceName);
        return db;
    }

    IFileResourceBuilder IFileResourceBuilder.WithName(string name) => WithName(name);
}
