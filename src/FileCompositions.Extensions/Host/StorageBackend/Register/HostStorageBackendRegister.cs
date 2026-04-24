using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Register;

internal delegate void HostStorageBackendRegister(in IServiceCollection services);
