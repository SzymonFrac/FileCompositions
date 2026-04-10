using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;
using System.Text.Json;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;

internal class JsonFileResourceBuilderFactory(JsonSerializerOptions serializerOptions) : IJsonFileResourceBuilderFactory
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = serializerOptions;

    public IJsonFileResourceBuilder<TData> Create<TData>(IFileResource baseFile) =>
        new JsonFileResourceBuilder<TData>(baseFile.Name, _jsonSerializerOptions);

    public IJsonFileResourceBuilder<TData> CreateDefault<TData>(string n) =>
        new JsonFileResourceBuilder<TData>(n, _jsonSerializerOptions);
}
