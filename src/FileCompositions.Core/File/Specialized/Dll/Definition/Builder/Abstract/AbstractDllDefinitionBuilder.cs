using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Abstract;

internal abstract partial class AbstractDllDefinitionBuilder<TOwnership, TPlacement>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>, IDllDefinitionBuilder<TOwnership, TPlacement>>,
    IDllDefinitionBuilder<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    protected IDllOptions Options { get; set; }

    public AbstractDllDefinitionBuilder(IDllOptions options) => Options = options;
    protected AbstractDllDefinitionBuilder(IDllOptions options, FileDefinitionKey? key = default) : base(key) => Options = options;

    public abstract IDllDefinitionBuilder<TNewOwnership, TNewPlacement> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
