using FileCompositions.Core.FileResource;

namespace FileCompositions.Core.FileResource.Specialized.Json.Builder.Factory;

internal interface IJsonFileResourceBuilderFactory
{
    IJsonFileResourceBuilder<TData> Create<TData>(IFileResource baseFile);
}
