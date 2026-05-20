using FileCompositions.Core.File.Interface.Specialized.Json.Format;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder;

namespace FileCompositions.Core.File.Interface.Specialized.Json.Builder.Factory;

internal interface IJsonResourceBuilderFactory
{
    IJsonResourceBuilder<TData> CreateDefault<TData>();
    IJsonResourceBuilder<TData> Create<TData>(JsonInterfaceFormat format);
}
