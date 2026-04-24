using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using FileCompositions.Core.Validation.Specialized.Json.Builder.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;

internal class JsonResourceBuilder<TData>(JsonResourceFormatContext format) : IJsonResourceBuilder<TData>
{
    private string? name;
    private JsonResourceFormatContext format = format;
    private IReadOnlyCollection<Func<IJsonResource<TData>, Task>>? validations;

    public IJsonResourceBuilder<TData> WithName(string n)
    {
        name = n;
        return this;
    }
    public IJsonResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        format = format with { JsonSerializerOptions = options };
        return this;
    }
    public IJsonResourceBuilder<TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation)
    {
        var builder = new JsonResourceValidationBuilder<TData>();
        validation(builder);
        validations = builder.Build();
        return this;
    }

    public IJsonResource<TData> Build(in IFileContext context)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var json = new JsonResource<TData>(context, name, format);
        return json;
    }
}
