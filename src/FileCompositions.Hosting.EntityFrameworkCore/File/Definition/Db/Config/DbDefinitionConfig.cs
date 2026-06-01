using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder.Factory;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> DbDefinitionConfig<TOwnership, TNecessity, TInNecessity, TDbContext>(IDbDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext;