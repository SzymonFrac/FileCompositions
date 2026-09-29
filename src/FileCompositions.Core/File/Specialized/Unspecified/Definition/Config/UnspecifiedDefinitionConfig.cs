using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Config;

public delegate IUnspecifiedDefinitionBuilder<TOwnership, TPlacement> UnspecifiedDefinitionConfig<TOwnership, TPlacement, TInPlacement>(INoFileDefinitionBuilder<Ownership.Internal, TInPlacement> config)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TInPlacement : Placement;