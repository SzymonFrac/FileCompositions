using FileCompositions.Core.Directory.Location.Builder.Implementations;
using FileCompositions.Core.File.LocationResolver;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Location.Builder.Factory.Implementations;

internal class DirectoryLocationBuilderFactory : IDirectoryLocationBuilderFactory
{
    public IDirectoryLocationBuilder Create(IStorageBackend storageBackend, IFileLocationResolver resolver) =>
        new DirectoryLocationBuilder(storageBackend, resolver);
}
