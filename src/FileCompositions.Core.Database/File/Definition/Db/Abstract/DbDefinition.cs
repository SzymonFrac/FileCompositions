using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.Database.File.Resource.Db.Abstract;
using FileCompositions.Core.Database.File.Resource.Db.Builder;
using FileCompositions.Core.Database.File.Resource.Db.Builder.Factory.Implementations;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Context.Implementations;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Abstract;

internal abstract class DbDefinition<TOwnership, TNecessity, TDbContext>(FileDefinitionKey key, IFileContext context, string name)
    : DbDefinition<TOwnership, TNecessity>(key, context, name), IDbDefinition<TOwnership, TNecessity, TDbContext>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;

internal abstract class DbDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IFileContext context, string name)
    : DbResource(context, name), IDbDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public FileDefinitionKey Key { get; } = key;
}

internal abstract class DbDefinition : IDbDefinition
{
    public static StorageResourceExtension Extension { get; } = new(".db");

    public static IDbResource Convert(IDirectoryLocation directory, StorageResourceName name, Action<IDbResourceBuilder>? config = default)
    {
        var factory = new DbFileResourceBuilderFactory();
        var builder = factory.CreateDefault();
        config?.Invoke(builder);

        var context = new FileContext(directory);
        var db = builder.Build(context);
        return db;
    }

    public static IFileResource Convert(IDirectoryLocation directory, StorageResourceName name) =>
        Convert(directory, name);
}