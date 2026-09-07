using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Config;

public delegate IJsonDefinitionBuilder<TOwnership, TPlacement, TData> JsonDefinitionConfig<TOwnership, TPlacement, TInPlacement, TData>(INoFileDefinitionBuilder<Ownership.Internal, TInPlacement> config)
    where TOwnership : Ownership
    where TPlacement : Placement
    where TInPlacement : Placement;
