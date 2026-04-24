using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Specialized.Json.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TNecessity, TData> JsonFileDefinitionConfig<TOwnership, TNecessity, TData>(IFileDefinitionBuilder config)
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
