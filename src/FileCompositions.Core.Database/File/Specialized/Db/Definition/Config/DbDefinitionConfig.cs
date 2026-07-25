using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TNecessity> DbDefinitionConfig<TOwnership, TNecessity, TInNecessity>(IDbDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity;
