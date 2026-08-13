using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(IDbDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        internal IDbDefinitionBuilder<StrictDefinition, TPlacement> Strict() =>
            builder.Create<StrictDefinition, TPlacement>();
        internal IDbDefinitionBuilder<ExternalDefinition, TPlacement> External() =>
            builder.Create<ExternalDefinition, TPlacement>();
    }
}
