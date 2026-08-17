using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;

internal sealed class DllDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IDllOptions> config)
    : AbstractDllDefinitionBuilder<TOwnership, TPlacement>(inner, config)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;