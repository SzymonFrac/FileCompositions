using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Implementations;

internal sealed class DbDefinition<TOwnership, TPlacement, TDbContext>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractDbDefinition<TOwnership, TPlacement, TDbContext>(context, key, name)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext;
