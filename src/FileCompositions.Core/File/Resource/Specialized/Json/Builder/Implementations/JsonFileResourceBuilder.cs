using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.File.Resource.Specialized.Json.Descriptor;
using FileCompositions.Core.File.Resource.Specialized.Json.Context.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.Descriptor.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.File.Resource.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using FileCompositions.Core.Validation.Specialized.Json.Builder.Implementations;
using System.Text.Json;
using FileCompositions.Core.File.Definition.Json.Extensions;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;

internal class JsonFileResourceBuilder<TData>(string n, JsonSerializerOptions s) : IJsonFileResourceBuilder<TData>
{
    private readonly string name = n;
    private JsonSerializerOptions serializerOptions = s;
    private IReadOnlyCollection<Func<IJsonFileResource<TData>, Task>>? validations;

    public IJsonFileResourceBuilder<TData> UseSerializerOptions(JsonSerializerOptions options)
    {
        serializerOptions = options;
        return this;
    }
    public IJsonFileResourceBuilder<TData> WithValidation(Action<IJsonResourceValidationBuilder<TData>> validation)
    {
        var builder = new JsonResourceValidationBuilder<TData>();
        validation(builder);
        validations = builder.Build();
        return this;
    }

    public IJsonFileResource<TData> Build(IDirectoryLocation directory)
    {
        var resourceName = StorageResourceName.CreateJson(name);
        var format = new JsonFileResourceFormatContext(serializerOptions);
        var context = new JsonFileResourceContext(directory);

        var json = new JsonFileResource<TData>(context, resourceName, format);
        return json;
    }
    public IJsonFileResourceDescriptor<TData> BuildDescriptor(DirectoryLocationKey key)
    {
        var resourceName = StorageResourceName.CreateJson(name);
        var format = new JsonFileResourceFormatContext(serializerOptions);

        var descriptor = new JsonFileResourceDescriptor<TData>(key, resourceName, format, validations);
        return descriptor;
    }
}
