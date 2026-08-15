using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> DbDefinitionConfig<TOwnership, TPlacement, TInPlacement, TDbContext>(INoDefinitionBuilder<StrictDefinition, TInPlacement> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInPlacement : DefinitionPlacement
    where TDbContext : DbContext;