using FileCompositions.Core.File.Specialized.Dll.Resource.Builder.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Resource.Builder.Factory.Implementations;

internal sealed class DllResourceBuilderFactory : IDllResourceBuilderFactory
{
    public static DllResourceBuilderFactory Default { get; } = new();

    public IDllResourceBuilder CreateDefault() => new DllResourceBuilder();
}
