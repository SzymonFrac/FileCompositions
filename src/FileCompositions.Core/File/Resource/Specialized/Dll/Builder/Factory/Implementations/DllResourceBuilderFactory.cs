using FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Factory.Implementations;

internal class DllResourceBuilderFactory : IDllResourceBuilderFactory
{
    public IDllResourceBuilder CreateDefault() => new DllResourceBuilder();
}
