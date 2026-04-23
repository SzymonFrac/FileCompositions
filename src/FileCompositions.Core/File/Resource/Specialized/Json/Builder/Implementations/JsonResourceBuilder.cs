using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition.Specialized.Json.Extensions;
using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json.Context.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;
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

    public IJsonResource<TData> Build(IDirectoryLocation directory)
    {
        if (name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var resourceName = StorageResourceName.CreateJson(name);
        var context = new JsonResourceContext(directory);

        var json = new JsonResource<TData>(context, resourceName, format);
        return json;
    }

    IFileResourceBuilder IFileResourceBuilder.WithName(string name) => WithName(name);
}
