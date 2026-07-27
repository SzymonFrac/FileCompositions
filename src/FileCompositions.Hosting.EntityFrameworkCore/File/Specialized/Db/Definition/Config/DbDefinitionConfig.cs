using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> DbDefinitionConfig<TOwnership, TNecessity, TInNecessity, TDbContext>(IDbDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext;