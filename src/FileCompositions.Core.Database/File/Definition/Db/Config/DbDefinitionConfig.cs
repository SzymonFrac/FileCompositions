using FileCompositions.Core.Database.File.Definition.Db.Builder;
using FileCompositions.Core.Database.File.Definition.Db.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Database.File.Definition.Db.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity> DbDefinitionConfig<TOwnership, TNecessity, TInNecessity>(IDbDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity;
