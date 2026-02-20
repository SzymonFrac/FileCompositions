using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Backend.ActivationContext;
using FileCompositions.Core.Storage.Backend.Container;
using FileCompositions.Core.Storage.Backend.Provider;
using FileCompositions.Extensions.Host.StorageBackend.Container.Implementations;

namespace FileCompositions.Extensions.Host.StorageBackend.ActivationContext.Implementations;

internal class HostStorageBackendActivationContext(HostStorageBackendContainer container) : IStorageBackendActivationContext
{
    private readonly IStorageBackendContainer _container = container;
    public IStorageBackend Activate(IStorageBackendProvider storageBackendProvider) =>
        storageBackendProvider.GetStorageBackend(in _container);
}
