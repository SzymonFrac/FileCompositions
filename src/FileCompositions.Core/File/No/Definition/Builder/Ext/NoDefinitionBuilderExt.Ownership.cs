using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal INoDefinitionBuilder<StrictDefinition, TPlacement> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        internal INoDefinitionBuilder<ExternalDefinition, TPlacement> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
