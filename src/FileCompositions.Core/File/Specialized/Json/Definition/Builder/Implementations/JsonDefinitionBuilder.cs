using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;
using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy.Implementations;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;

internal sealed class JsonDefinitionBuilder<TOwnership, TNecessity, TData>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IJsonDefinitionBuilder<TOwnership, TNecessity, TData>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private bool initializeWithSerialize = false;
    private JsonFormat format;
    private TData? @default;

    internal JsonDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) =>
        format = JsonFormat.Default;
    private JsonDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name, JsonFormat f, TData? d = default)
        : base(directoryKey, key, name) =>
            (format, @default) = (f ?? JsonFormat.Default, d);

    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithName(string name)
    {
        Name = name;
        return this;
    }
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        format = format with { JsonSerializerOptions = options };
        return this;
    }
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseDefault(TData d)
    {
        @default = d;
        return this;
    }
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> InitializeWithSerialization()
    {
        initializeWithSerialize = true;
        return this;
    }

    public IJsonDefinitionBuilder<ExternalDefinition, TNecessity, TData> External() =>
        new JsonDefinitionBuilder<ExternalDefinition, TNecessity, TData>(DirectoryKey, Key, Name, format, @default);
    public IJsonDefinitionBuilder<StrictDefinition, TNecessity, TData> Strict() =>
        new JsonDefinitionBuilder<StrictDefinition, TNecessity, TData>(DirectoryKey, Key, Name, format, @default);
    public IJsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> Required() =>
        new JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData>(DirectoryKey, Key, Name, format, @default);
    public IJsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> Optional() =>
        new JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData>(DirectoryKey, Key, Name, format, @default);


    public IJsonDefinition<TOwnership, TPlacement, TData> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new JsonDefinition<TOwnership, TPlacement, TData>(context, Key, Name, format, @default)
        { 
            InitPolicy = initializeWithSerialize
                ? new SerializeJsonInitPolicy<TOwnership, TPlacement, TData>()
                : new DefaultJsonInitPolicy<TOwnership, TPlacement, TData>()
        };
    }

    public IJsonDefinitionDescriptor<TOwnership, TPlacement, TData> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(DirectoryKey, Key, Name, format, @default)
        {
            InitPolicy = initializeWithSerialize
                ? new SerializeJsonInitPolicy<TOwnership, TPlacement, TData>()
                : new DefaultJsonInitPolicy<TOwnership, TPlacement, TData>()
        };
    }
}
