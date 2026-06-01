using FileCompositions.Core.File.Definition.Specialized.Dll.Builder;
using FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Config;

public delegate IDllDefinitionBuilder<TOwnership, TNecessity> DllDefinitionConfig<TOwnership, TNecessity, TInNecessity>(IDllDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity;