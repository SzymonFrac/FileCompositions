using FileCompositions.Core.File.Specialized.Json.Resource.Builder.Implementations;

namespace FileCompositions.Core.File.Specialized.Json.Resource.Builder.Factory.Implementations;

internal sealed class JsonResourceBuilderFactory : IJsonResourceBuilderFactory
{
    public static JsonResourceBuilderFactory Default { get; } = new();

    public IJsonResourceBuilder<TData> CreateDefault<TData>() =>
        new JsonResourceBuilder<TData>();

}
