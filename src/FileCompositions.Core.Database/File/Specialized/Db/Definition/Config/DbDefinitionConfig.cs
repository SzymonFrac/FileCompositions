using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;
using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Config;

public delegate IDbDefinitionBuilder<TOwnership, TPlacement> DbDefinitionConfig<TOwnership, TPlacement, TInPlacement>(INoFileDefinitionBuilder<Ownership.Internal, TInPlacement> config)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TInPlacement : Placement;
