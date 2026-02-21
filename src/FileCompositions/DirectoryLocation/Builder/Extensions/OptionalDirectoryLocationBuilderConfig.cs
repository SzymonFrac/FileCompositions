using FileCompositions.Core.DirectoryLocation.Factory.Implementations;

namespace FileCompositions.Core.DirectoryLocation.Builder.Extensions;

public static class OptionalDirectoryLocationBuilderConfig
{
    extension(IDirectoryLocationBuilder builder)
    {
        public IDirectoryLocationBuilder Optional() => builder.UseFactory(new OptionalDirectoryLocationFactory());
    }
}
