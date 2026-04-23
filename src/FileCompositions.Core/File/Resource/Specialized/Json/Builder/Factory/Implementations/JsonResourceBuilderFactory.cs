using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;

internal class JsonResourceBuilderFactory(JsonResourceFormatContext format) : IJsonResourceBuilderFactory
{
    private readonly JsonResourceFormatContext _jsonSerializerOptions = format;

    public IJsonResourceBuilder<TData> CreateDefault<TData>() =>
        new JsonResourceBuilder<TData>(_jsonSerializerOptions);
    public IJsonResourceBuilder<TData> Create<TData>(JsonResourceFormatContext format) =>
        new JsonResourceBuilder<TData>(format);

}
