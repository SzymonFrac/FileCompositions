using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Extensions.Host.StorageBackend.Provider;

internal delegate IStorageBackend HostStorageBackendProvider(ref IServiceProvider provider);
