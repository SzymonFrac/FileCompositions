using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Json.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Implementations;

internal class JsonDefinitionBuilder<TOwnership, TNecessity, TData>(JsonResourceFormatContext format)
    : JsonResourceBuilder<TData>(format), IJsonDefinitionBuilder<TOwnership, TNecessity, TData>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    private FileDefinitionKey key;
    private string? name;
    private JsonResourceFormatContext format = format;

    public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey k)
    {
        key = k;
        return this;
    }
    new public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithName(string n)
    {
        name = n;
        return this;
    }
    new public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        format = format with { JsonSerializerOptions = options };
        return this;
    }
    new public IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation)
    {
        throw new NotImplementedException();
    }

    new public JsonDefinition<TOwnership, TNecessity, TData> Build(in IFileContext context)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new StandardJsonDefinition<TOwnership, TNecessity, TData>(key, context, name, format);
        return json;
    }

    public IJsonDefinitionDescriptor<TOwnership, TNecessity, TData> BuildDescriptor()
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new JsonDefinitionDescriptor<TOwnership, TNecessity, TData>(key, name, format);
        return json;
    }
}
