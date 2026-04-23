using FileCompositions.Core.File.Definition.Specialized.Json.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TNecessity, TData> JsonFileDefinitionConfig<TOwnership, TNecessity, TData>(IJsonDefinitionBuilder<StrictDefinition, RequiredDefinition, TData> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
