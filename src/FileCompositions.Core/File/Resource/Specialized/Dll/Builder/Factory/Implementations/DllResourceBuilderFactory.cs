using FileCompositions.Core.File.Interface.Specialized.Dll.Builder;
using FileCompositions.Core.File.Interface.Specialized.Dll.Builder.Factory;
using FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Factory.Implementations;

internal sealed class DllResourceBuilderFactory : IDllResourceBuilderFactory
{
    public static DllResourceBuilderFactory Default { get; } = new();

    public IDllResourceBuilder CreateDefault() => new DllResourceBuilder();
}
