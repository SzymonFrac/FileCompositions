using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;

internal sealed class JsonDefinitionBuilder<TOwnership, TPlacement, TData> :
    AbstractJsonDefinitionBuilder<TOwnership, TPlacement, TData>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public JsonDefinitionBuilder(IJsonOptions<TData> options) : base(options) { }
    private JsonDefinitionBuilder(IJsonOptions<TData> options, FileDefinitionKey? key) : base(options, key) { }

    public override IJsonDefinitionBuilder<TNewOwnership, TNewPlacement, TData> Create<TNewOwnership, TNewPlacement>() =>
        new JsonDefinitionBuilder<TNewOwnership, TNewPlacement, TData>(Options, Key);

    public override IJsonDefinitionBuilder<TOwnership, TPlacement, TData> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
}