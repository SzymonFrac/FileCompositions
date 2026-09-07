using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;

internal sealed class JsonDefinitionBuilder<TOwnership, TPlacement, TData>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IJsonOptions<TData>> config) :
    AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData>(inner, config)
        where TOwnership : Ownership
        where TPlacement : Placement;