using FileCompositions.Core.Schema.Resources.Registrar;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Registrar;

namespace FileCompositions.Extensions.Host.Schema.Resources.Registrar;

public interface IHostResourceSchemaResourcesRegistrar : IResourceSchemaResourcesRegistrar
{
    IHostResourceSchemaResourcesRegistrar Files(Action<IHostResourceSchemaFileResourceRegistrar> config);
};