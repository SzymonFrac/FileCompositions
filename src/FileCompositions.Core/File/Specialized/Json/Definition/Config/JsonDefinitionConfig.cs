using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TPlacement, TData> JsonDefinitionConfig<TOwnership, TPlacement, TInNecessity, TData>(IFileDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInNecessity : DefinitionNecessity;
