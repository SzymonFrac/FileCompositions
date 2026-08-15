using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Config;

public delegate IDllDefinitionBuilder<TOwnership, TPlacement> DllDefinitionConfig<TOwnership, TPlacement, TInPlacement>(INoDefinitionBuilder<StrictDefinition, TInPlacement> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInPlacement : DefinitionPlacement;