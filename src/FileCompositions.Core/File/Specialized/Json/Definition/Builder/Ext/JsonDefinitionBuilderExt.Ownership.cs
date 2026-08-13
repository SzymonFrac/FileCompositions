using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TPlacement, TData>(IJsonDefinitionBuilder<TOwnership, TPlacement, TData> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal IJsonDefinitionBuilder<StrictDefinition, TPlacement, TData> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        internal IJsonDefinitionBuilder<ExternalDefinition, TPlacement, TData> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
