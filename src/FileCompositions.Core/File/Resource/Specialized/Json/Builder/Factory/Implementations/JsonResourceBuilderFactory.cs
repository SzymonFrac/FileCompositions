using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;

internal sealed class JsonResourceBuilderFactory : IJsonResourceBuilderFactory
{
    public static JsonResourceBuilderFactory Default { get; } = new();

    public IJsonResourceBuilder<TData> CreateDefault<TData>() =>
        new JsonResourceBuilder<TData>();

}
