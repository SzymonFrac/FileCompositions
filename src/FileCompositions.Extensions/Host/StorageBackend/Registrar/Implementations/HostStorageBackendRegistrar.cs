using FileCompositions.Core.Schema.StorageBackend.Registrar;
using FileCompositions.Core.Storage.Backend;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.StorageBackend.Registrar.Implementations;

internal class HostStorageBackendRegistrar(ref IServiceCollection services, ref IServiceCollection settingServices) : IResourceSchemaStorageBackendRegistrar
{
    private readonly IServiceCollection _services = services;
    private readonly IServiceCollection _settingServices = settingServices;
    public IResourceSchemaStorageBackendRegistrar Register<TBackend>()
        where TBackend : class, IStorageBackend
    {
        _services.AddSingleton<TBackend>();
        _settingServices.AddSingleton<TBackend>();
        return this;
    }
}
