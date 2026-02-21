using FileCompositions.Core.Schema.Resources.FileResource.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;

public interface IHostResourceSchemaFileResourceRegistrar : IResourceSchemaFileResourceRegistrar
{
    IHostResourceSchemaFileResourceRegistrar Store(Action<IHostResourceSchemaFileResourceStoreTo> config);
    IServiceProvider CurrentSettingsAvailable();
}
