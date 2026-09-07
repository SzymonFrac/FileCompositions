using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Implementations;

internal sealed class DbDefinition<TOwnership, TPlacement, TDbContext>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractDbDefinition<TOwnership, TPlacement, TDbContext>(context, key, name)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDbContext : DbContext;
