using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.No.Definition.Builder.Ext;

public static partial class NoFileDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> builder)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        public INoFileDefinitionBuilder<Ownership.Internal, TPlacement> Strict() =>
            builder.Create<Ownership.Internal, TPlacement>();
        public INoFileDefinitionBuilder<Ownership.External, TPlacement> External() =>
            builder.Create<Ownership.External, TPlacement>();
    }
}
