using FileCompositions.Core.Directory.Location.Builder.Implementations;

namespace FileCompositions.Core.Directory.Location.Builder.Factory.Implementations;

internal sealed class DirectoryLocationBuilderFactory : IDirectoryLocationBuilderFactory
{
    public IDirectoryLocationBuilder Create() => new DirectoryLocationBuilder();
}
