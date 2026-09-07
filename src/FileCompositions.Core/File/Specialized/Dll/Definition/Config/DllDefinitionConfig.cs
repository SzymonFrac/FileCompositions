using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Config;

public delegate IDllDefinitionBuilder<TOwnership, TPlacement> DllDefinitionConfig<TOwnership, TPlacement, TInPlacement>(INoFileDefinitionBuilder<Ownership.Internal, TInPlacement> config)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TInPlacement : Placement;