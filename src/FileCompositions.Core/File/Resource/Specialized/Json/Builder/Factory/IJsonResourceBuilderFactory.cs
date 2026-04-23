using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory;

internal interface IJsonResourceBuilderFactory
{
    IJsonResourceBuilder<TData> CreateDefault<TData>();
    IJsonResourceBuilder<TData> Create<TData>(JsonResourceFormatContext format);
}
