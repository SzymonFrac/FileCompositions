using FileCompositions.Core.Database.File.Definition.Db.Abstract;
using FileCompositions.Core.Database.File.Resource.Db.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Implementations;

internal class DbDefinition<TOwnership, TNecessity, TDbContext>(FileDefinitionKey key, IDbResourceContext context, StorageResourceName name)
    : AbstractDbDefinition<TOwnership, TNecessity, TDbContext>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDbContext : DbContext;

internal class DbDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IDbResourceContext context, StorageResourceName name)
    : AbstractDbDefinition<TOwnership, TNecessity>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
