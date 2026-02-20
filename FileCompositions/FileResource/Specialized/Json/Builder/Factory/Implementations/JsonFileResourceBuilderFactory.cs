using FileCompositions.Core.FileResource.Specialized.Json.Builder.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.FileResource.Specialized.Json.Builder.Factory.Implementations;

internal class JsonFileResourceBuilderFactory(JsonSerializerOptions serializerOptions) : IJsonFileResourceBuilderFactory
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = serializerOptions;
    public IJsonFileResourceBuilder<TData> Create<TData>(IFileResource baseFile) =>
        new JsonFileResourceBuilder<TData>(baseFile, _jsonSerializerOptions);
}
