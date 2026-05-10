using FileCompositions.Core.File.Definition.Specialized.Json.Builder;
using FileCompositions.Core.File.Definition.Specialized.Json.Builder.Factory;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TNecessity, TData> JsonFileDefinitionConfig<TOwnership, TNecessity, TInOwnership, TInNecessity, TData>(IJsonDefinitionBuilderFactory<TInOwnership, TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity;
