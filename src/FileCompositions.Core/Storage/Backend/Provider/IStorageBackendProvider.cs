using FileCompositions.Core.Storage.Backend.Container;

namespace FileCompositions.Core.Storage.Backend.Provider;

internal interface IStorageBackendProvider
{
    IStorageBackend GetStorageBackend(in IStorageBackendContainer container);
}
