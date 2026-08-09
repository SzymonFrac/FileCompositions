using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;

public class JsonDefinitionBuilder<TOwnership, TNecessity, TData>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, JsonDefinitionBuilder<TOwnership, TNecessity, TData>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IJsonConfig<TData> _config;

    public JsonDefinitionBuilder(IJsonConfig<TData> config) => _config = config;
    protected JsonDefinitionBuilder(IJsonConfig<TData> config, FileDefinitionKey? key = default) : base(key) => _config = config;

    protected override JsonDefinitionBuilder<TOwnership, TNecessity, TData> Create<TNewOwnership, TNewNecessity>() => new(_config, Key);

    public override JsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public JsonDefinitionBuilder<ExternalDefinition, TNecessity, TData> External() => new(_config, Key);
    public JsonDefinitionBuilder<StrictDefinition, TNecessity, TData> Strict() => new(_config, Key);
    public JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> Required() => new(_config, Key);
    public JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> Optional() => new(_config, Key);

    internal FileDefinitionRequestDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build<TPlacement>(out FileDefinitionKey key)
        where TPlacement : DefinitionPlacement
    {
        if (Key is null)
            throw new NullReferenceException("File must have a key.");

        key = Key;

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }
}
