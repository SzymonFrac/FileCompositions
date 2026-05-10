using FileCompositions.Core.File.Interface.Specialized.Dll.Builder.Implementations;

namespace FileCompositions.Core.File.Interface.Specialized.Dll.Builder.Factory.Implementations;

internal class DllResourceBuilderFactory : IDllResourceBuilderFactory
{
    public IDllResourceBuilder CreateDefault() => new DllResourceBuilder();
}
