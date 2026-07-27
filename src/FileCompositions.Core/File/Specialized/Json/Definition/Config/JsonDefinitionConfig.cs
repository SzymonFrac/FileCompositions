using FileCompositions.Core.File.Specialized.Json.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TNecessity, TData> JsonDefinitionConfig<TOwnership, TNecessity, TInNecessity, TData>(IJsonDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInNecessity : DefinitionNecessity;
