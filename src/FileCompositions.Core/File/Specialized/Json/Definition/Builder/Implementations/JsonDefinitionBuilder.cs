using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;

public class JsonDefinitionBuilder<TOwnership, TNecessity, TData>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, JsonDefinitionBuilder<TOwnership, TNecessity, TData>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IJsonOptions<TData> _options;

    public JsonDefinitionBuilder(IJsonOptions<TData> options) => _options = options;
    protected JsonDefinitionBuilder(IJsonOptions<TData> options, FileDefinitionKey? key = default) : base(key) => _options = options;

    public override JsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public JsonDefinitionBuilder<ExternalDefinition, TNecessity, TData> External() => new(_options, Key);
    public JsonDefinitionBuilder<StrictDefinition, TNecessity, TData> Strict() => new(_options, Key);
    public JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> Required() => new(_options, Key);
    public JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> Optional() => new(_options, Key);

    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build<TPlacement>(DirectoryDefinitionKey directoryKey)
        where TPlacement : DefinitionPlacement
    {
        var key = BuildKey();

        var descriptor = _options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
