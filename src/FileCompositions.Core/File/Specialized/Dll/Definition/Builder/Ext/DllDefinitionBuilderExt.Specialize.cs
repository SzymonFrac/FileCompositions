using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

public static partial class DllDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : Ownership
        where TPlacement : Placement
    {
        public IDllDefinitionBuilder<TOwnership, TPlacement> Dll(Action<IDllOptions> config) =>
            new DllDefinitionBuilder<TOwnership, TPlacement>(inner, config);
    }
}
