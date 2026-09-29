using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Unspecified.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Ext;

public static partial class UnspecifiedDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        public IUnspecifiedDefinitionBuilder<TOwnership, TPlacement> Unspecified(Action<IUnspecifiedOptions> config) =>
            new UnspecifiedDefinitionBuilder<TOwnership, TPlacement>(inner, config);
    }
}
