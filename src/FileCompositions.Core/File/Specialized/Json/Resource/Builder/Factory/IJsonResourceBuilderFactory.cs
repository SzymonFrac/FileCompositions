namespace FileCompositions.Core.File.Specialized.Json.Resource.Builder.Factory;

internal interface IJsonResourceBuilderFactory
{
    IJsonResourceBuilder<TData> CreateDefault<TData>();
}
