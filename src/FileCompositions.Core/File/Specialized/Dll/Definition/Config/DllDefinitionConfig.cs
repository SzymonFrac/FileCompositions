using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Config;

public delegate IDllDefinitionBuilder<TOwnership, TPlacement> DllDefinitionConfig<TOwnership, TPlacement, TInNecessity>(IFileDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInNecessity : DefinitionNecessity;