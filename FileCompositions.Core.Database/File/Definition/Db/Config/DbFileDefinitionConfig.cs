using FileCompositions.Core.Database.File.Definition.Db.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Core.Database.File.Definition.Db.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity> DbFileDefinitionConfig<TOwnership, TNecessity>(IDbDefinitionBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity, TDbContext> DbFileDefinitionConfig<TOwnership, TNecessity, TDbContext>(IDbDefinitionBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TDbContext : DbContext;
