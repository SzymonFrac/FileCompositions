using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TPlacement> DbDefinitionConfig<TOwnership, TPlacement, TInPlacement>(INoDefinitionBuilder<StrictDefinition, TInPlacement> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInPlacement : DefinitionPlacement;
