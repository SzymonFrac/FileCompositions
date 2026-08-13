using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;

internal abstract partial class AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>, IJsonDefinitionBuilder<TOwnership, TPlacement, TData>>,
    IJsonDefinitionBuilder<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    protected IJsonOptions<TData> Options { get; set; }

    public AbstractJsonDefinitionBuilder(IJsonOptions<TData> options) => Options = options;
    protected AbstractJsonDefinitionBuilder(IJsonOptions<TData> options, FileDefinitionKey? key = default) : base(key) => Options = options;

    public abstract IJsonDefinitionBuilder<TNewOwnership, TNewPlacement, TData> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
