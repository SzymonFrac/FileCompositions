using FileCompositions.Core.Directory.Location.Builder.Implementations;

namespace FileCompositions.Core.Directory.Location.Builder.Factory.Implementations;

internal class DirectoryLocationBuilderFactory : IDirectoryLocationBuilderFactory
{
    public IDirectoryLocationBuilder Create() => new DirectoryLocationBuilder();
}
