using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

public static partial class DllDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        public IDllDefinitionBuilder<TOwnership, TPlacement> Dll(Action<IDllOptions> config) =>
            new DllDefinitionBuilder<TOwnership, TPlacement>(inner, config);
    }
}
