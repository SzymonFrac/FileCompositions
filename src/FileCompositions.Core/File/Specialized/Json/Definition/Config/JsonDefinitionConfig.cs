using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TPlacement, TData> JsonDefinitionConfig<TOwnership, TPlacement, TInPlacement, TData>(INoFileDefinitionBuilder<StrictDefinition, TInPlacement> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInPlacement : DefinitionPlacement;
