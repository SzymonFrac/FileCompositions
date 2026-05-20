using FileCompositions.Core.File.Interface.Specialized.Json.Builder.Factory;
using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;

internal class JsonResourceBuilderFactory(JsonInterfaceFormat format) : IJsonResourceBuilderFactory
{
    public static JsonResourceBuilderFactory Default { get; } = new(JsonInterfaceFormat.Default);

    private readonly JsonInterfaceFormat _jsonSerializerOptions = format;

    public IJsonResourceBuilder<TData> CreateDefault<TData>() =>
        new JsonResourceBuilder<TData>(_jsonSerializerOptions);
    public IJsonResourceBuilder<TData> Create<TData>(JsonInterfaceFormat format) =>
        new JsonResourceBuilder<TData>(format);

}
