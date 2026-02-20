using FileCompositions.Core.Storage.Backend.Provider;

namespace FileCompositions.Core.Storage.Backend.ActivationContext;

internal interface IStorageBackendActivationContext
{
    IStorageBackend Activate(IStorageBackendProvider storageBackendProvider);
}
