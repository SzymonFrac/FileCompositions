using FileCompositions.Core.File.Definition.Specialized.Dll.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Config;

internal delegate IDllDefinitionBuilder<TOwnership, TNecessity> DllFileDefinitionConfig<TOwnership, TNecessity>(IDllDefinitionBuilder<StrictDefinition, RequiredDefinition> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;