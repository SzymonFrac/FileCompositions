using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.DirectoryLocation.Builder.Factory;

internal interface IDirectoryLocationBuilderFactory
{
    IDirectoryLocationBuilder Create(IStorageBackendProvider storageBackend);
}
