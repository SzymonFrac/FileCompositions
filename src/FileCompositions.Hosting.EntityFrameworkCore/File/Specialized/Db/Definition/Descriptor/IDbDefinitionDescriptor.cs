using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;

internal delegate IDbDefinition<TOwnership, TPlacement, TDbContext> DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(FileDefinitionKey key, IFileContext context)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDbContext : DbContext;
