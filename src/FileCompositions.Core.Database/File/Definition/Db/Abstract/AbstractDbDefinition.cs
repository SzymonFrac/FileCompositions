using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.Database.File.Resource.Db.Builder;
using FileCompositions.Core.Database.File.Resource.Db.Builder.Factory.Implementations;
using FileCompositions.Core.Database.File.Resource.Db.Context;
using FileCompositions.Core.Database.File.Resource.Db.Implementations;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TNecessity, TDbContext>(FileDefinitionKey key, IDbResourceContext context, StorageResourceName name)
    : AbstractDbDefinition<TOwnership, TNecessity>(key, context, name), IDbDefinition<TOwnership, TNecessity, TDbContext>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;

internal abstract class AbstractDbDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IDbResourceContext context, StorageResourceName name)
    : AbstractDbDefinition(context, name), IDbDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public FileDefinitionKey Key { get; } = key;
}

internal abstract class AbstractDbDefinition(IDbResourceContext context, StorageResourceName name)
    : DbResource(context, name), IDbDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".db");

    public static IDbResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDbResourceBuilder>? config = default)
    {
        var factory = new DbFileResourceBuilderFactory();
        var builder = factory.CreateDefault();
        config?.Invoke(builder);
        var db = builder.Build(directory);
        return db;
    }
    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}