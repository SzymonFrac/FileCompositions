namespace FileCompositions.Core.File.Resource.Specialized.Json.Builder.Factory;

internal interface IJsonFileResourceBuilderFactory
{
    IJsonFileResourceBuilder<TData> Create<TData>(IFileResource baseFile);
    IJsonFileResourceBuilder<TData> CreateDefault<TData>(string name);
}
