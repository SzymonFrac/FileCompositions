using FileCompositions.Core.File.Specialized.Unspecified.Resource.Builder.Implementations;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource.Builder.Factory.Implementations;

internal sealed class UnspecifiedResourceBuilderFactory : IUnspecifiedResourceBuilderFactory
{
    public static UnspecifiedResourceBuilderFactory Default { get; } = new();

    public IUnspecifiedResourceBuilder CreateDefault() => new UnspecifiedResourceBuilder();
}
