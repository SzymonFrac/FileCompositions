using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Name;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Abstract;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement, TDbContext>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractDbDefinition<TOwnership, TPlacement>(context, key, name), IDbDefinition<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;

internal abstract class AbstractDbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : FileDefinition<TOwnership, TPlacement>(context, key, StorageResourceName.CreateDb(name)), IDbDefinition<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
