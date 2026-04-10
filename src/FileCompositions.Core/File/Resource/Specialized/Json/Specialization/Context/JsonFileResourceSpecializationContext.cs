using FileCompositions.Core.File.Resource.Specialized.Json.Builder;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory;
using FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Json.Specialization.Context;

internal sealed class JsonFileResourceSpecializationContext(IJsonFileResourceBuilderFactory jsonFactory)
{
    public static JsonFileResourceSpecializationContext Default => new(new JsonFileResourceBuilderFactory(new()));
    public static JsonFileResourceSpecializationContext Indented => new(new JsonFileResourceBuilderFactory(new()
    {
        WriteIndented = true
    }));

    private readonly IJsonFileResourceBuilderFactory _jsonFactory = jsonFactory;
    public IJsonFileResourceBuilder<TData> CreateBuilder<TData>(IFileResource baseFile) =>
        _jsonFactory.Create<TData>(baseFile);
}
