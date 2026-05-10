using FileCompositions.Core.Database.File.Definition.Db.Builder;
using FileCompositions.Core.Database.File.Definition.Db.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> DbFileDefinitionConfig<TOwnership, TNecessity, TInOwnership, TInNecessity, TDbContext>(IDbDefinitionBuilderFactory<TInOwnership, TInNecessity, TDbContext> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity> DbFileDefinitionConfig<TOwnership, TNecessity, TInOwnership, TInNecessity>(IDbDefinitionBuilderFactory<TInOwnership, TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity;
