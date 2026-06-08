namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory;

internal interface IJsonResourceBuilderFactory
{
    IJsonResourceBuilder<TData> CreateDefault<TData>();
}
