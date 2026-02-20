using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar.Implementations;

internal class HostResourceSchemaFileResourceRegistrar(ref IServiceCollection services, ref IServiceCollection other) : IHostResourceSchemaFileResourceRegistrar
{
    private readonly IServiceCollection _services = services;
    private readonly IServiceCollection _other = other;

    public IHostResourceSchemaFileResourceRegistrar Store(Action<IHostResourceSchemaFileResourceStoreTo> config)
    {
        var store = new HostResourceSchemaFileResourceStore();
        config(store);
        var register = store.BuildRegister();
        register.Register(in _services);
        register.RegisterSettings(in _other);

        return this;
    }
    public IServiceProvider CurrentSettingsAvailable() => _other.BuildServiceProvider();
}
