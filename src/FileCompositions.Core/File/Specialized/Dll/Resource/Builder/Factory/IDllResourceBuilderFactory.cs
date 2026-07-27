using FileCompositions.Core.File.Specialized.Dll.Resource.Builder;

namespace FileCompositions.Core.File.Specialized.Dll.Resource.Builder.Factory;

internal interface IDllResourceBuilderFactory
{
    IDllResourceBuilder CreateDefault();
}
