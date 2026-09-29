using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Unspecified.Options;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Builder.Implementations;

internal sealed class UnspecifiedDefinitionBuilder<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner, Action<IUnspecifiedOptions> config)
    : AbstractUnspecifiedDefinitionBuilder<TOwnership, TPlacement>(inner, config)
        where TOwnership : Ownership
        where TPlacement : Placement;