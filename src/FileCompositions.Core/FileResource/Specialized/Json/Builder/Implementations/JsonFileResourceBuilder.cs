using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Specialized.Json.Context.Implementations;
using FileCompositions.Core.FileResource.Specialized.Json.Descriptor;
using FileCompositions.Core.FileResource.Specialized.Json.Descriptor.Implementations;
using FileCompositions.Core.FileResource.Specialized.Json.FormatContext;
using FileCompositions.Core.FileResource.Specialized.Json.Implementations;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Validation.Specialized.Json.Builder;
using FileCompositions.Core.Validation.Specialized.Json.Builder.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.FileResource.Specialized.Json.Builder.Implementations;

internal class JsonFileResourceBuilder<TData>(IFileResource baseFile, JsonSerializerOptions serializerOptions) : IJsonFileResourceBuilder<TData>
{
    private readonly IFileResource _baseFile = baseFile;
    private JsonSerializerOptions serializerOptions = serializerOptions;
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
        var name = StorageResourceName.Create(_baseFile.Name, ".json");
        var format = new JsonFileResourceFormatContext(serializerOptions);
        var context = new JsonFileResourceContext(directory);

        var json = new JsonFileResource<TData>(context, name, format);
        return json;

    }
    public IJsonFileResourceDescriptor<TData> BuildDescriptor(DirectoryLocationKey key)
    {
        var name = StorageResourceName.Create(_baseFile.Name, ".json");
        var format = new JsonFileResourceFormatContext(serializerOptions);

        var descriptor = new JsonFileResourceDescriptor<TData>(key, name, format, validations);
        return descriptor;
    }

}
