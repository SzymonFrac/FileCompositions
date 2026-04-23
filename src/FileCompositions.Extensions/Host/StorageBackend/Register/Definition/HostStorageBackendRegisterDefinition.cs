using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Register.Definition;

internal delegate void HostStorageBackendRegisterDefinition(ref IServiceCollection services);
