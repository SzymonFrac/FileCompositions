using FileCompositions.Core.File.Specialized.Dll.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Config;

public delegate IDllDefinitionBuilder<TOwnership, TNecessity> DllDefinitionConfig<TOwnership, TNecessity, TInNecessity>(IDllDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity;