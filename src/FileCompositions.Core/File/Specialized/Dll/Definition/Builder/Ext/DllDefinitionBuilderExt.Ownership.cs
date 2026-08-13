using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

public static partial class DllDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(IDllDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal IDllDefinitionBuilder<StrictDefinition, TPlacement> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        internal IDllDefinitionBuilder<ExternalDefinition, TPlacement> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
