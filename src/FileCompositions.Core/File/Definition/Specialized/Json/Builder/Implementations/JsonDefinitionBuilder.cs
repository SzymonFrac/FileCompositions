using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Implementations;

internal class JsonDefinitionBuilder<TOwnership, TNecessity, TData>
    : FileDefinitionBuilder<TOwnership, TNecessity>, IJsonDefinitionBuilder<TOwnership, TNecessity, TData>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private JsonInterfaceFormat format;

    internal JsonDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) =>
        format = JsonInterfaceFormat.Default;
    private JsonDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name, JsonInterfaceFormat format)
        : base(directoryKey, key, name) =>
            this.format = format ?? JsonInterfaceFormat.Default;

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
    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation)
    {
        throw new NotImplementedException();
    }

    public IJsonDefinitionBuilder<ExternalDefinition, TNecessity, TData> External() =>
        new JsonDefinitionBuilder<ExternalDefinition, TNecessity, TData>(DirectoryKey, Key, Name, format);
    public IJsonDefinitionBuilder<StrictDefinition, TNecessity, TData> Strict() =>
        new JsonDefinitionBuilder<StrictDefinition, TNecessity, TData>(DirectoryKey, Key, Name, format);
    public IJsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> Required() =>
        new JsonDefinitionBuilder<TOwnership, RequiredDefinition, TData>(DirectoryKey, Key, Name, format);
    public IJsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> Optional() =>
        new JsonDefinitionBuilder<TOwnership, OptionalDefinition, TData>(DirectoryKey, Key, Name, format);


    public IJsonDefinition<TOwnership, TPlacement, TData> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new StandardJsonDefinition<TOwnership, TPlacement, TData>(Key, context, Name, format);
        return json;
    }

    public IJsonDefinitionDescriptor<TOwnership, TPlacement, TData> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(DirectoryKey, Key, Name, format);
        return json;
    }
}
