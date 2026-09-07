using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext> DbDefinitionConfig<TOwnership, TPlacement, TInPlacement, TDbContext>(INoFileDefinitionBuilder<Ownership.Internal, TInPlacement> config)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TInPlacement : Placement
    where TDbContext : DbContext;