using FileCompositions.Core.Schema.Resources.FileResource.Store.Components;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Definition;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Mux;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Store.Components;

public interface IHostResourceSchemaFileResourceStoreRegister : IResourceSchemaFileResourceStoreRegister
{
    void Register(Func<IHostResourceSchemaFileResourceRegisterMux, HostFileResourceRegisterDefinition> config);
};
