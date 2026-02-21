using FileCompositions.Core.DirectoryLocation.Builder.Implementations;
using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Builder.Factory.Implementations;

internal class DirectoryLocationBuilderFactory : IDirectoryLocationBuilderFactory
{
    public IDirectoryLocationBuilder Create(IStorageBackendProvider storageBackend) =>
        new DirectoryLocationBuilder(storageBackend);
}
