using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public INoFileDefinitionBuilder<StrictDefinition, TPlacement> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        public INoFileDefinitionBuilder<ExternalDefinition, TPlacement> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
