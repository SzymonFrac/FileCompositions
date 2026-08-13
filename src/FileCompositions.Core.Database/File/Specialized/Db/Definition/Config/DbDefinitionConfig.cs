using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;
using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TPlacement> DbDefinitionConfig<TOwnership, TPlacement, TInNecessity>(IFileDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInNecessity : DefinitionNecessity;
