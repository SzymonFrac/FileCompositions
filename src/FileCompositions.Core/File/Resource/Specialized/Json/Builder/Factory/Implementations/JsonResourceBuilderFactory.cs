using FileCompositions.Core.File.Interface.Specialized.Json.Builder.Implementations;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Builder.Factory.Implementations;

internal class JsonResourceBuilderFactory(JsonInterfaceFormat format) : IJsonResourceBuilderFactory
{
    private readonly JsonInterfaceFormat _jsonSerializerOptions = format;

    public IJsonResourceBuilder<TData> CreateDefault<TData>() =>
        new JsonResourceBuilder<TData>(_jsonSerializerOptions);
    public IJsonResourceBuilder<TData> Create<TData>(JsonInterfaceFormat format) =>
        new JsonResourceBuilder<TData>(format);

}
